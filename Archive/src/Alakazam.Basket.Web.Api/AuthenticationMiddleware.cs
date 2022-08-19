using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Alakazam.Basket.Web.Api
{
    public sealed class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private string[] _excludeLinks = new string[] { "/swagger" };

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(_excludeLinks.Any(x=>context.Request.Path.ToString().ToLower().StartsWith(x.ToLower()))){
                await _next(context);
                return;
            }

            string authHeader = context.Request.Headers["user-id"];
            if (!string.IsNullOrEmpty(authHeader))
            {
                context.User = new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(new[]{
                    new Claim("id",authHeader)
                }));
                await _next(context);
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }
    }
}