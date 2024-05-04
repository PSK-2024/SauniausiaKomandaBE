namespace SaunausiaKomanda.API.Startup
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DocumentTitle = "Šaunausia Komanda API";
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }


            app.UseCors("corsapp");
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
    }
}
