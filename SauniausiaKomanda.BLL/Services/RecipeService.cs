using AutoMapper;
using SauniausiaKomanda.DAL.Enums;
using SauniausiaKomanda.BLL.Filters;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;
using SauniausiaKomanda.DAL.Entities;

namespace SauniausiaKomanda.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageWriter _imageWriter;
        private readonly IIdentityService _identityService;

        public RecipeService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IImageWriter imageWriter, 
            IIdentityService identityService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageWriter = imageWriter;
            _identityService = identityService;
        }

        public async Task<DetailedRecipeResponseDTO> GetRecipeByIdAsync(int id)
        {
            var user = await _identityService.GetCurrentUser();

            var recipe = await _unitOfWork.Recipes.GetAsync(x => x.Id == id);
            if (recipe == null)
            {
                throw new Exception("Invalid recipeId provided"); //TODO: think how to handle incorrect requests
            }

            var result = _mapper.Map<DetailedRecipeResponseDTO>(recipe);

            foreach (var ingredient in recipe.Ingredients)
            {
                var ingredientGroup = result.Ingredients.Find(x => x.GroupName == ingredient.Group);
                if (ingredientGroup != null)
                {
                    ingredientGroup.Items.Add(new DetailedRecipeIngredientItemsDTO { Name = ingredient.Description });
                }
                else
                {
                    ingredientGroup = new DetailedRecipeIngredientsResponseDTO { GroupName = ingredient.Group };
                    ingredientGroup.Items.Add(new DetailedRecipeIngredientItemsDTO { Name = ingredient.Description });
                    result.Ingredients.Add(ingredientGroup);
                }
            }

            if (user.Favorites.Any(x => x.RecipeId == recipe.Id))
            {
                result.isFavorite = true;
            }

            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetRecipesShortAsync(string? categoryFilter)
        {
            var user = await _identityService.GetCurrentUser();
            var queryPred = PredicateBuilder.True<Recipe>();

            if (categoryFilter != null)
            {
                var categoryPred = PredicateBuilder.False<Recipe>();
                foreach (var categoryToFetch in categoryFilter.Split(","))
                {
                    categoryPred = categoryPred.Or(x => x.Categories.Any(c => c.Name == categoryToFetch));
                }

                queryPred = queryPred.And(categoryPred);
            }

            var allRecipes = await _unitOfWork.Recipes.GetManyAsync(queryPred);
            var result = _mapper.Map<List<ShortRecipeResponseDTO>>(allRecipes.ToList());

            foreach (var recipe in result)
            {
                if (user.Favorites.Any(x => x.RecipeId == recipe.Id))
                {
                    recipe.isFavorite = true;
                }
            }

            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetRecommendedAsync(int top)
        {
            var allRecipes = await _unitOfWork.Recipes.GetManyAsync(orderBy: x => x.OrderByDescending(p => p.Reviews.Average(r => r.Stars)), itemsToTake: top);
            var result = _mapper.Map<List<ShortRecipeResponseDTO>>(allRecipes.ToList());

            return result;
        }

        public async Task<int> CreateRecipeAsync(CreateRecipeRequestDTO recipeToCreate)
        {
            var recipe = new Recipe
            {
                Title = recipeToCreate.Title,
                PreparationTimeInMinutes = recipeToCreate.PreparationTimeInMinutes,
                Calories = recipeToCreate.Calories
            };

            var createdBy = await _unitOfWork.Users.GetAsync(x => x.Id == 1) ?? throw new Exception("User not found"); //TODO: after auth is created get current user
            recipe.User = createdBy;

            var image = await _imageWriter.SaveImageAsync(recipeToCreate.Image);
            var imageEntity = new Image { Value = image, ImageLocation = ImageLocation.Fileserver };
            recipe.Image = imageEntity;

            foreach (var category in recipeToCreate.Categories)
            {
                var categoryEntity = await _unitOfWork.Categories.GetAsync(x => x.Name == category) ?? throw new Exception("Category not found");
                recipe.Categories.Add(categoryEntity);
            }

            foreach (var (step, i) in recipeToCreate.Steps.Select((step, i) => (step, i)))
            {
                var stepEntity = new Step { Description = step, Sequence = i };
                recipe.Steps.Add(stepEntity);
            }

            foreach (var ingredientGroup in recipeToCreate.IngredientGroups)
            {
                foreach (var ingredient in ingredientGroup.Ingredients)
                {
                    var ingredientEntity = new Ingredient { Description = ingredient, Group = ingredientGroup.Group };
                    recipe.Ingredients.Add(ingredientEntity);
                }
            }
            await _unitOfWork.Recipes.CreateAsync(recipe);
            await _unitOfWork.SaveAsync();

            return recipe.Id;
        }

        public async Task AddFavorite(FavoriteRequestDTO favoriteToAdd)
        {
            var user = await _identityService.GetCurrentUser();

            var favorite = new Favorite { UserId = user.Id, RecipeId = favoriteToAdd.RecipeId };
            user.Favorites.Add(favorite);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveFavorite(FavoriteRequestDTO favoriteToRemove)
        {
            var user = await _identityService.GetCurrentUser();

            var favorite = user.Favorites.FirstOrDefault(x => x.UserId == user.Id && x.RecipeId == favoriteToRemove.RecipeId) ?? throw new Exception("You have not favorited this recipe");
            user.Favorites.Remove(favorite);
            await _unitOfWork.SaveAsync();
        }
    }
}
