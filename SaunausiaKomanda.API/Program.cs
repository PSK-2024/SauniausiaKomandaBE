using SauniausiaKomanda.API.Startup;

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();