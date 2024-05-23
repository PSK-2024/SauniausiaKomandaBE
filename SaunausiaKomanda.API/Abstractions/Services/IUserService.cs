using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IUserService
    {
        public Task<MyUserProfileResponseDTO> GetCurrentUserAsync();
        public Task<UserProfileResponseDTO> GetProfileByIdAsync(int id);
    }
}
