using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;

namespace SaunausiaKomanda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _userService;

        public ProfileController(IProfileService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            return Ok(await _userService.GetCurrentUserProfileAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("posted")]
        public async Task<IActionResult> GetPostedRecipes()
        {
            return Ok(await _userService.GetPostedRecipesAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("favorite")]
        public async Task<IActionResult> GetFavoriteRecipes()
        {
            return Ok(await _userService.GetFavoriteRecipesAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileUpdateRequestDTO updateRequest)
        {
            return Ok(await _userService.UpdateCurrentUserProfile(updateRequest));
        }
    }
}
