namespace SaunausiaKomanda.API.Startup
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Services.AddApplicationInsightsTelemetry();
            builder.Services.RegisterApplicationServices(config);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }
}
