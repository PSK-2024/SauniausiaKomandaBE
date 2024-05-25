using AutoMapper;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;
using SauniausiaKomanda.DAL.Entities;

namespace SauniausiaKomanda.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public ReviewService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IIdentityService identityService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<DetailedRecipeResponseDTO> AddReviewAsync(AddReviewRequestDTO reviewToAdd)
        {
            var review = _mapper.Map<Review>(reviewToAdd);
            var user = await _identityService.GetCurrentUser();
            review.UserId = user.Id;
            await _unitOfWork.Reviews.CreateAsync(review);

            await _unitOfWork.SaveAsync();

            var recipe = await _unitOfWork.Recipes.GetAsync(x => x.Id == review.RecipeId) ?? throw new Exception("Internal error");
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
    }
}
