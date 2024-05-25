using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;

namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface IRecipeService
    {
        public Task<DetailedRecipeResponseDTO> GetRecipeByIdAsync(int id);
        public Task<List<ShortRecipeResponseDTO>> GetRecommendedAsync(int top);
        public Task<List<ShortRecipeResponseDTO>> GetRecipesShortAsync(string? categoryFilter);
        public Task<int> CreateRecipeAsync(CreateRecipeRequestDTO recipeToCreate);
        public Task AddFavorite(FavoriteRequestDTO favoriteToAdd);
        public Task RemoveFavorite(FavoriteRequestDTO favoriteToRemove);
    }
}
