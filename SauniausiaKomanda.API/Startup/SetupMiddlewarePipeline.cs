using SauniausiaKomanda.API.Middleware;

namespace SauniausiaKomanda.API.Startup
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Šauniausia Komanda API";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseCors("corsapp");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();           

            app.MapControllers();

            return app;
        }
    }
}
