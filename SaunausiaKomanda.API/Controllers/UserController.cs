using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;

namespace SaunausiaKomanda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ActionName(nameof(GetUserById))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            return Ok(await _userService.GetProfileByIdAsync(userId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(await _userService.GetCurrentUserAsync());
        }
    }
}
