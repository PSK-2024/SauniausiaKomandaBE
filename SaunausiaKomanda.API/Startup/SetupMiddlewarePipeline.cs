namespace SaunausiaKomanda.API.Startup
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.DocumentTitle = "Šaunausia Komanda API";
                });
            }


            app.UseCors("corsapp");
            app.MapControllers();

            return app;
        }
    }
}
