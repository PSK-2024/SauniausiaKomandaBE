using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SauniausiaKomanda.DAL.Repositories.Abstractions;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.DAL.Data;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Repositories;
using SauniausiaKomanda.BLL.Services;
using SauniausiaKomanda.API.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SauniausiaKomanda.API.Startup
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
                var filePath = Path.Combine(AppContext.BaseDirectory, "SauniausiaKomanda.API.xml");
                o.IncludeXmlComments(filePath);
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddCors(options =>
                options.AddPolicy("corsapp", builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                }));

            DAL.Container.RegisterDataAccessServices.RegisterDbContext(services, config);
            DAL.Container.RegisterDataAccessServices.RegisterServices(services);
            BLL.Container.BusinessLayerServices.RegisterServices(services);

            return services;
        }
    }
}
