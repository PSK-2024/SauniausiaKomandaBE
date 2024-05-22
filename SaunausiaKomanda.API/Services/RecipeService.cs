using AutoMapper;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.Controllers;
using SaunausiaKomanda.API.Data;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;
using SaunausiaKomanda.API.Entities;
using SaunausiaKomanda.API.Enums;
using SaunausiaKomanda.API.Filters;

namespace SaunausiaKomanda.API.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageWriter _imageWriter;

        public RecipeService(IUnitOfWork unitOfWork, IMapper mapper, IImageWriter imageWriter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageWriter = imageWriter;
        }

        public async Task<DetailedRecipeResponseDTO> GetRecipeByIdAsync(int id)
        {
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

            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetRecipesShortAsync(string? categoryFilter)
        {
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

            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetRecommendedAsync(int top)
        {
            // TODO: Need to check after more reviews/recipes are added [sus]
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
            // todo: prob insert

            foreach (var category in recipeToCreate.Categories)
            {
                var categoryEntity = await _unitOfWork.Categories.GetAsync(x => x.Name == category) ?? throw new Exception("Category not found");
                recipe.Categories.Add(categoryEntity);
            }

            foreach (var (step, i) in recipeToCreate.Steps.Select((step, i) => (step, i)))
            {
                var stepEntity = new Step { Description = step, Sequence = i };
                recipe.Steps.Add(stepEntity);
                // todo: probably need to insert
            }

            foreach (var ingredientGroup in recipeToCreate.IngredientGroups)
            {
                foreach (var ingredient in ingredientGroup.Ingredients)
                {
                    var ingredientEntity = new Ingredient { Description = ingredient, Group = ingredientGroup.Group };
                    recipe.Ingredients.Add(ingredientEntity);
                    // todo: probably need to insert
                }
            }
            await _unitOfWork.Recipes.CreateAsync(recipe);
            await _unitOfWork.SaveAsync();

            return recipe.Id;
        }
    }
}
