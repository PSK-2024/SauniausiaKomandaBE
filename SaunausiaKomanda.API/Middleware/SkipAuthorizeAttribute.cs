using Microsoft.AspNetCore.Mvc.Filters;

namespace SauniausiaKomanda.API.Middleware
{
    public class SkipAuthorizeAttribute : Attribute, IFilterMetadata
    {
    }
}
