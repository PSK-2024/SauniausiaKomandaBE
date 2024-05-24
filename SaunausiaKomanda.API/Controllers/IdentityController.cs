using Azure;
using Microsoft.AspNetCore.Mvc;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.API.Middleware;

namespace SauniausiaKomanda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [SkipAuthorize]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var response = await _identityService.LoginAsync(loginDto);

            if (response.Token == "")
            {
                return Unauthorized();
            }

            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                return Ok(await _identityService.GetUserFromJwtToken(token));
            }

            return Unauthorized();
        }
    }
}
