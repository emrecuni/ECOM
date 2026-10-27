using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace ECOM.MVC.Infrastructure.Handlers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // token ayrı bir cookie'de değil; login sırasında StoreTokens ile şifreli auth cookie'sinin içine "access_token" adıyla yazılır
            var httpContext = _httpContextAccessor.HttpContext;
            var token = httpContext is null ? null : await httpContext.GetTokenAsync("access_token");
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
