using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

namespace Fdo.Api.Contato.Vistoria.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var apiException = exception as NotImplementedException;
            _logger.Error(apiException, "Error: {@exception}", apiException.Message);
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;

            return await Task.FromResult(context);
        }
    }
}
