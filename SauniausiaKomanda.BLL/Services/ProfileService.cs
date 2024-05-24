using AutoMapper;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.DTOs.Request;
using SauniausiaKomanda.BLL.DTOs.Response;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Enums;

namespace SauniausiaKomanda.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IImageWriter _imageWriter;

        public ProfileService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IIdentityService identityService,
            IImageWriter imageWriter
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityService = identityService;
            _imageWriter = imageWriter;
        }

        public async Task<UserProfileResponseDTO> GetCurrentUserProfileAsync()
        {
            var userId = (await _identityService.GetCurrentUser()).Id;
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == userId);

            var result = _mapper.Map<UserProfileResponseDTO>(user);
            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetPostedRecipesAsync()
        {
            var currentUser = await _identityService.GetCurrentUser();
            var recipes = currentUser.Recipes;

            var result = _mapper.Map<List<ShortRecipeResponseDTO>>(recipes);
            foreach (var recipe in result)
            {
                if (currentUser.Favorites.Any(x => x.RecipeId == recipe.Id))
                {
                    recipe.isFavorite = true;
                }
            }

            return result;
        }

        public async Task<List<ShortRecipeResponseDTO>> GetFavoriteRecipesAsync()
        {
            var currentUser = await _identityService.GetCurrentUser();
            var recipes = currentUser.Favorites.Select(x => x.Recipe);

            var result = _mapper.Map<List<ShortRecipeResponseDTO>>(recipes);
            foreach (var recipe in result)
            {
                recipe.isFavorite = true;
            }

            return result;
        }

        public async Task<UserProfileResponseDTO> UpdateCurrentUserProfile(
            UserProfileUpdateRequestDTO updateRequest
        )
        {
            var currentUser = await _identityService.GetCurrentUser();

            currentUser.FirstName = updateRequest.FirstName;
            currentUser.LastName = updateRequest.LastName;
            currentUser.About = updateRequest.About;

            var image = await _imageWriter.SaveImageAsync(updateRequest.Image);
            var imageEntity = new Image { Value = image, ImageLocation = ImageLocation.Fileserver };

            if (currentUser.Image != null)
            {
                _imageWriter.DeleteImage(currentUser.Image.Value);
                _unitOfWork.Images.Delete(currentUser.Image);
            }

            currentUser.Image = imageEntity;

            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<UserProfileResponseDTO>(currentUser);
            return result;
        }
    }
}
