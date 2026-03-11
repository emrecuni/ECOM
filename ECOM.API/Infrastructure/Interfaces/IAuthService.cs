using ECOM.Shared.Data.DTOs;
using ECOM.Api.Data.Entities;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        public Task<Customers?> ValidateUser(LoginRequestDto model);
        public Task<bool> CheckExistsCustomer(RegisterRequestDto model);
        public Task SendVerifyEmail(RegisterRequestDto model);
        public Task<Customers> Register(RegisterRequestDto model);
    }
}
