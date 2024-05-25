using AutoMapper;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Response;

namespace SauniausiaKomanda.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponseDTO>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var result = _mapper.Map<List<CategoryResponseDTO>>(categories.ToList());

            return result;
        }
    }
}
