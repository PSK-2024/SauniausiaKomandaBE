using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;
using SauniausiaKomanda.DAL.Entities;

namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface IIdentityService
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<UserDTO> GetUserFromJwtToken(string token);
        Task<User> GetCurrentUser();
    }
}
