
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Alakazam.Basket.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Alakazam.Basket.Web.Api
{
    public sealed class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    message = ex.Message,
                    helpLink = ex.HelpLink
                }));

                if (((int)ex.StatusCode) >= 500)
                    _logger.LogError(ex, ex.Message);
                else if (((uint)ex.StatusCode) < 500 && ((uint)ex.StatusCode) >= 400)
                {
                    _logger.LogWarning(ex, ex.Message);
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    message = "unexpected error"
                }));
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}