using Microsoft.AspNetCore.Mvc.Filters;

namespace SaunausiaKomanda.API.Middleware
{
    public class SkipAuthorizeAttribute : Attribute, IFilterMetadata
    {
    }
}
