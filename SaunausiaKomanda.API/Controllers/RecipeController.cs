using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;

namespace SaunausiaKomanda.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ActionName("GetRecipe")]
        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipe([FromRoute] int recipeId)
        {
            return Ok(await _recipeService.GetRecipeById(recipeId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("preview")]
        public async Task<IActionResult> GetRecipesShort()
        {

            return Ok(await _recipeService.GetRecipesShort());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommended([FromQuery] int top = 5)
        {
            return Ok(await _recipeService.GetRecommended(top));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequestDTO recipeToCreate)
        {
            return Created("GetName", new { id = await _recipeService.CreateRecipe(recipeToCreate)});
        }
    }
}
