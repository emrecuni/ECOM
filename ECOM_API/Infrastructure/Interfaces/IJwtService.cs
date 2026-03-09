using System.Security.Claims;
using ECOM_API.Data.Entity;

namespace ECOM_API.Infrastructure.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(Customers customer);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
