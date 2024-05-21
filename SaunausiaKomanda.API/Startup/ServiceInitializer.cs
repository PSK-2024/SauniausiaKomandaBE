using Microsoft.EntityFrameworkCore;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Data;
using SaunausiaKomanda.API.Data.Repositories;

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

            services.AddCors(options =>
                options.AddPolicy("corsapp", builder => {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                }));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            RegisterDbContext(services, config);
            RegisterDataAccessServices(services);
            
            return services;
        }

        private static void RegisterDbContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => { 
                options.UseSqlServer(config.GetConnectionString("SQLCONNSTR_DefaultConnection")); 
            });
        }


        private static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}
