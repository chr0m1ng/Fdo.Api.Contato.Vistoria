using Microsoft.AspNetCore.Mvc.Filters;

namespace Fdo.Api.Contato.Vistoria.Facades.Extensions
{
    public static class FilterContextExtensions
    {
        public static T GetSingleton<T>(this AuthorizationFilterContext context) where T : class
        {
            return context.HttpContext.RequestServices.GetService(typeof(T)) as T;
        }
    }
}
