using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.DTOs.Request;
using SaunausiaKomanda.API.DTOs.Response;
using SaunausiaKomanda.API.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaunausiaKomanda.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly DefaultPasswordOptions _defaultPasswordOptions;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IdentityService(
            IOptions<JwtOptions> jwtOptions,
            IOptionsSnapshot<DefaultPasswordOptions> defaultPasswordOptions,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _jwtOptions = jwtOptions.Value;
            _defaultPasswordOptions = defaultPasswordOptions.Value;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserFromJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userEmailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;

            var user = await _unitOfWork.Users.GetAsync(x => x.Email == userEmailClaim);

            var result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            if (!await CheckIfUserExists(loginDto.Email) ||
                !CheckIfPasswordMatches(loginDto.Password))
            {
                return new LoginResponseDTO(""); 
            }

            var token = GenerateToken(loginDto);
            return new LoginResponseDTO(token);
        }

        private bool CheckIfPasswordMatches(string password)
        {
            return password == _defaultPasswordOptions.Password;
        }

        private async Task<bool> CheckIfUserExists(string email)
        {
            return await _unitOfWork.Users.AnyAsync(x => x.Email.Equals(email));
        }

        private string GenerateToken(LoginDTO loginDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, loginDto.Email),
                new(JwtRegisteredClaimNames.Email, loginDto.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.LifetimeInMinutes),
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
