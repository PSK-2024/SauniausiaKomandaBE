using AutoMapper;
using SaunausiaKomanda.API.DTOs.Response;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.DTOs.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, ShortRecipeResponseDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.Value))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(x => x.Name).ToList()));
            CreateMap<Recipe, DetailedRecipeResponseDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.Value))
                .ForMember(dest => dest.Ingredients, opt => opt.Ignore());

            CreateMap<Review, DetailedRecipeReviewResponseDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.UserPicture, opt => opt.MapFrom(src => src.User.Image != null ? src.User.Image.Value : "defaultprofile.jpg"));

            CreateMap<Step, DetailedRecipeInstructionResponseDTO>();

            CreateMap<Category, DetailedRecipeCategoryDTO>();
            CreateMap<Category, CategoryResponseDTO>();

            CreateMap<User, UserProfileResponseDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.Image != null ? src.Image.Value : "defaultprofile.jpg"));

            CreateMap<User, MyUserProfileResponseDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.Image != null ? src.Image.Value : "defaultprofile.jpg"));
        }
    }
}
