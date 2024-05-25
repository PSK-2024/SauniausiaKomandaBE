using Microsoft.Extensions.DependencyInjection;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Data;
using SauniausiaKomanda.DAL.Repositories.Abstractions;
using SauniausiaKomanda.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SauniausiaKomanda.DAL.Container
{
    public static class RegisterDataAccessServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
        }

        public static void RegisterDbContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
