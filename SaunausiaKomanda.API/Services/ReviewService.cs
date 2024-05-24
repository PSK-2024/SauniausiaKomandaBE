using AutoMapper;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public ReviewService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IIdentityService identityService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<DetailedRecipeResponseDTO> AddReviewAsync(AddReviewRequestDTO reviewToAdd)
        {
            var review = _mapper.Map<Review>(reviewToAdd);
            review.UserId = (await _identityService.GetCurrentUser()).Id;
            await _unitOfWork.Reviews.CreateAsync(review);

            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<DetailedRecipeResponseDTO>(await _unitOfWork.Recipes.GetAsync(x => x.Id == review.RecipeId));
            return result;
        }
    }
}
