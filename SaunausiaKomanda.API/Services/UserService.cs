using AutoMapper;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Response;

namespace SaunausiaKomanda.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MyUserProfileResponseDTO> GetCurrentUserAsync()
        {
            var userId = 1; // TODO: get from token
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == userId);

            var result = _mapper.Map<MyUserProfileResponseDTO>(user);
            return result;
        }

        public async Task<UserProfileResponseDTO> GetProfileByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Invalid userId provided");
            }

            var result = _mapper.Map<UserProfileResponseDTO>(user);
            return result;
        }
    }
}
