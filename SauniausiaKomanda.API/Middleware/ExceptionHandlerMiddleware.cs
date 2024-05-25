using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace SauniausiaKomanda.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var (status, message) = GetResponse(exception);
                response.StatusCode = (int)status;
                await response.WriteAsync(JsonSerializer.Serialize(new { message }));
            }
        }

        private (HttpStatusCode code, string message) GetResponse(Exception exception) 
        {
            HttpStatusCode code;
            string message;

            switch(exception)
            {
                case DbUpdateConcurrencyException:
                    code = HttpStatusCode.Conflict;
                    message = "Someone changed the record since you last read it. Please reload the data and try again.";
                    break;
                case InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            return (code, message);
        }
    }
}
