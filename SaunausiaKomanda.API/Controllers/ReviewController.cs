using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.Services;

namespace SaunausiaKomanda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] AddReviewRequestDTO reviewToAdd)
        {
            return Ok(await _reviewService.AddReviewAsync(reviewToAdd));
        }
    }
}
