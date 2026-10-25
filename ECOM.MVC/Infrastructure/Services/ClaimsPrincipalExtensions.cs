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
    }
}
