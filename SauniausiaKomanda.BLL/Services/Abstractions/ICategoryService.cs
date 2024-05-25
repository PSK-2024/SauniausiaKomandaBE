using SauniausiaKomanda.BLL.DTOs.Response;

namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetCategoriesAsync();
    }
}
