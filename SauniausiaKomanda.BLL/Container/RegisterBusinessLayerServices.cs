using Microsoft.Extensions.DependencyInjection;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.BLL.Services;

namespace SauniausiaKomanda.BLL.Container
{
    public static class BusinessLayerServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IImageWriter, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
