﻿using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.Middleware;

namespace SaunausiaKomanda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController: ControllerBase
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
    }
}
