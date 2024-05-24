using Microsoft.AspNetCore.Mvc;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Request;

namespace SauniausiaKomanda.API.Controllers
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
