using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.Entities;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        public Task<Customers?> ValidateUser(LoginRequestDto model);
        public Task<bool> CheckExistsCustomer(CheckCustomerDto model);
        public Task<Response<SmtpResponseDto>> SendVerifyEmail(SmtpRequestDto model);
        public Task<bool> SaveOtpCode(OtpRequestDto model);
        public Task<Response<RegisterResponseDto>> Register(RegisterRequestDto model);
        public Task<Response<OtpResponseDto>> CheckOtpInDb(OtpRequestDto model);
        public Task<Response<ForgotPasswordResponseDto>> ForgotPassword(ForgotPasswordRequestDto model);
    }
}
