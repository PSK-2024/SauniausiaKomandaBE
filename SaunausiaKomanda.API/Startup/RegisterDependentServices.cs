namespace SaunausiaKomanda.API.Startup
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Services.RegisterApplicationServices(config);

            return builder;
        }
    }
}
