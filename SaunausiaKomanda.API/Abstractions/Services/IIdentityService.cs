using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IIdentityService
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);
    }
}
