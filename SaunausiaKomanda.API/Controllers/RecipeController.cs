using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions;

namespace SaunausiaKomanda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public IConfiguration _config; 

        public RecipeController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        /// <summary>
        /// Retrieves all recipes
        /// </summary>
        /// <response code="200">All recipes retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {

            var value = _config.GetConnectionString("DefaultConnection");
            var value2 = _config.GetConnectionString("SQLCONNSTR_DefaultConnection");


            return Ok(value + " <> " + value2);
        }
    }
}
