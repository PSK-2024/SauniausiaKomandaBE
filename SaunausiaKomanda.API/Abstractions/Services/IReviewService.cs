using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IReviewService
    {
        public Task<DetailedRecipeResponseDTO> AddReviewAsync(AddReviewRequestDTO reviewToAdd);
    }
}
