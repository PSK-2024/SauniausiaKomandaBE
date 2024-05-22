using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IRecipeService
    {
        public Task<DetailedRecipeResponseDTO> GetRecipeByIdAsync(int id);
        public Task<List<ShortRecipeResponseDTO>> GetRecommendedAsync(int top);
        public Task<List<ShortRecipeResponseDTO>> GetRecipesShortAsync(string? categoryFilter);
        public Task<int> CreateRecipeAsync(CreateRecipeRequestDTO recipeToCreate);
    }
}
