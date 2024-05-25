﻿using SauniausiaKomanda.API.Middleware;

namespace SauniausiaKomanda.API.Startup
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            //TODO: For easier debugging
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Šauniausia Komanda API";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            //}


            app.UseCors("corsapp");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseStaticFiles();
            app.MapControllers();

            return app;
        }
    }
}
