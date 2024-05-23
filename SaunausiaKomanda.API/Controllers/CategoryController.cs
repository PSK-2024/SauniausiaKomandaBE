using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.Abstractions.Services;

namespace SaunausiaKomanda.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ActionName("GetCategories")]
        [HttpGet("all")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }
    }
}
