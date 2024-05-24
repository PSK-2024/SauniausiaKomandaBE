using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Abstractions.Services;
using SaunausiaKomanda.API.Data;
using SaunausiaKomanda.API.Data.Repositories;
using SaunausiaKomanda.API.Services;
using SaunausiaKomanda.API.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SaunausiaKomanda.API.Startup
{
    public static class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddControllers();            
            services.AddSwaggerGen(o =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "SaunausiaKomanda.API.xml");
                o.IncludeXmlComments(filePath);
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddCors(options =>
                options.AddPolicy("corsapp", builder => {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                }));

            RegisterDbContext(services, config);
            RegisterDataAccessServices(services);
            RegisterBusinessLayerServices(services);


            return services;
        }

        private static void RegisterDbContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")); 
            });
        }


        private static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }

        private static void RegisterBusinessLayerServices(IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IImageWriter, ImageToFileService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
