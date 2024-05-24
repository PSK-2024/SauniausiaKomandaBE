using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IIdentityService
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<UserDTO> GetUserFromJwtToken(string token);
        Task<User> GetCurrentUser();
    }
}
