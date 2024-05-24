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
        [ActionName(nameof(GetRecipeById))]
        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] int recipeId)
        {
            return Ok(await _recipeService.GetRecipeByIdAsync(recipeId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("preview")]
        public async Task<IActionResult> GetShort([FromQuery] string? categoryFilter)
        {
            return Ok(await _recipeService.GetRecipesShortAsync(categoryFilter));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommended([FromQuery] int top = 5)
        {
            return Ok(await _recipeService.GetRecommendedAsync(top));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequestDTO recipeToCreate)
        {
            return Created(nameof(GetRecipeById), new { id = await _recipeService.CreateRecipeAsync(recipeToCreate)});
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("favorite")]
        public async Task<IActionResult> RemoveFavorite([FromBody] FavoriteRequestDTO favoriteToDelete)
        {
            await _recipeService.RemoveFavorite(favoriteToDelete);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("favorite")]
        public async Task<IActionResult> AddFavorite([FromBody] FavoriteRequestDTO favoriteToAdd)
        {
            await _recipeService.AddFavorite(favoriteToAdd);
            return NoContent();
        }
    }
}
