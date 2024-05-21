using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IRecipeService
    {
        public Task<DetailedRecipeResponseDTO> GetRecipeById(int id);
        public Task<List<ShortRecipeResponseDTO>> GetRecommended(int top);
        public Task<List<ShortRecipeResponseDTO>> GetRecipesShort();
        public Task<int> CreateRecipe(CreateRecipeRequestDTO recipeToCreate);
    }
}
