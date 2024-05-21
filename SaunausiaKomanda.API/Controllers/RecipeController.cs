using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions;

namespace SaunausiaKomanda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all recipes
        /// </summary>
        /// <response code="200">All recipes retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {   
            var allRecipes = await _unitOfWork.Recipes.GetAllAsync();

            return Ok(allRecipes);
        }
    }
}
