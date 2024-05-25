using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;

namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface IReviewService
    {
        public Task<DetailedRecipeResponseDTO> AddReviewAsync(AddReviewRequestDTO reviewToAdd);
    }
}
