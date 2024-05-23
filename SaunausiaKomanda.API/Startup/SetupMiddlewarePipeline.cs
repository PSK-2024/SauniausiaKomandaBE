namespace SaunausiaKomanda.API.Startup
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
                    options.DocumentTitle = "Šaunausia Komanda API";
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            //}


            app.UseCors("corsapp");
            app.UseHttpsRedirection();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            return app;
        }
    }
}
