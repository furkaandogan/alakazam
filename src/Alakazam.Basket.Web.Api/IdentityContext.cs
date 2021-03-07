using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Alakazam.Basket.Web.Api
{
    public sealed class IdentityContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Identity Get()
        {
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Request != null &&
                _httpContextAccessor.HttpContext.Request.Headers != null &&
                _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("user-id"))
            {
                return new Identity
                {
                    Id = Guid.Parse(_httpContextAccessor.HttpContext.Request.Headers["user-id"].ToString())
                };
            }

            throw new AuthenticationException();
        }
    }
}
