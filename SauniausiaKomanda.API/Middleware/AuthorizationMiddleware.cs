using Microsoft.AspNetCore.Mvc;

namespace SauniausiaKomanda.API.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();

            if (!context.User.Identity!.IsAuthenticated)
            {
                if (endpoint != null)
                {
                    var skipAuthorize = endpoint.Metadata.GetMetadata<SkipAuthorizeAttribute>();

                    if (skipAuthorize == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
