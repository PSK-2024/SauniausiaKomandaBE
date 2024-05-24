using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IProfileService
    {
        public Task<UserProfileResponseDTO> GetCurrentUserProfileAsync();
        public Task<List<ShortRecipeResponseDTO>> GetPostedRecipesAsync();
        public Task<List<ShortRecipeResponseDTO>> GetFavoriteRecipesAsync();
        public Task<UserProfileResponseDTO> UpdateCurrentUserProfile(UserProfileUpdateRequestDTO updateRequest);
    }
}
