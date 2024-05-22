using Microsoft.AspNetCore.Mvc;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetCategoriesAsync();
    }
}
