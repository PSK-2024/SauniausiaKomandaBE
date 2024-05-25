using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.BLL.Options;
using System.Security.Claims;

namespace SauniausiaKomanda.API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork, IOptionsSnapshot<BLL.Options.LoggingOptions> loggingOptions)
        {
            if (context.User.Identity?.IsAuthenticated != true)
            {
                await _next(context);
                return;
            }

            if (loggingOptions.Value.IsLoggingOn)
            {
                var endpoint = context.GetEndpoint()!.Metadata.GetMetadata<ControllerActionDescriptor>();
                var userEmail = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value ?? "";

                Log log = new()
                {
                    UserEmail = userEmail,
                    Endpoint = endpoint?.ControllerTypeInfo.FullName + '.' + endpoint?.ActionName,
                    LoggedAt = DateTime.UtcNow
                };

                await unitOfWork.Logs.CreateAsync(log);
                await unitOfWork.Logs.SaveAsync();
            }

            await _next(context);
        }
    }
}
