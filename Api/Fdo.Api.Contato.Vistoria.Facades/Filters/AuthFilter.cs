using System;

using Fdo.Api.Contato.Vistoria.Facades.Extensions;
using Fdo.Api.Contato.Vistoria.Models.UI;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fdo.Api.Contato.Vistoria.Facades.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private ApiSettings _apiSettings { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            InitializeSingletons(context);
            if (context.HttpContext.Request.Headers.TryGetValue(_apiSettings.AuthHeader, out var authKey)
                && authKey == _apiSettings.ApiKey)
            {
                return;
            }
            context.Result = new UnauthorizedResult();
        }

        private void InitializeSingletons(AuthorizationFilterContext context)
        {
            _apiSettings ??= context.GetSingleton<ApiSettings>();
        }
    }
}
