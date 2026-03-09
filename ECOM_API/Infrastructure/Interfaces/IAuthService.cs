using ECOM_API.Data.Entity;
using ECOM_API.Data.Models;

namespace ECOM_API.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        public Task<Customers?> ValidateUser(LoginRequestDto model);
    }
}
