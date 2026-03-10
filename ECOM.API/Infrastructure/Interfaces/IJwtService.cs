using System.Security.Claims;
using ECOM.Api.Data.Entities;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(Customers customer);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
