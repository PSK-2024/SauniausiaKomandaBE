using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;

namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface IProfileService
    {
        public Task<UserProfileResponseDTO> GetCurrentUserProfileAsync();
        public Task<List<ShortRecipeResponseDTO>> GetPostedRecipesAsync();
        public Task<List<ShortRecipeResponseDTO>> GetFavoriteRecipesAsync();
        public Task<UserProfileResponseDTO> UpdateCurrentUserProfile(UserProfileUpdateRequestDTO updateRequest);
    }
}
