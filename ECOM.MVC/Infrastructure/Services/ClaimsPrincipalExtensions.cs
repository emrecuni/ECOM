using System.Security.Claims;

namespace ECOM.MVC.Infrastructure.Services
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetCustomerId(this ClaimsPrincipal user)
        {
            var value = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(value, out var customerId))
                throw new UnauthorizedAccessException("Geçerli kullanıcı kimliği bulunamadı.");

            return customerId;
        }

        // giriş yapmadan da açılabilen sayfalar için; misafirde 0 döner (api 0 id ile favori bilgisi olmadan ürün döner)
        public static int GetCustomerIdOrDefault(this ClaimsPrincipal user)
        {
            return int.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out var customerId) ? customerId : 0;
        }
    }
}
