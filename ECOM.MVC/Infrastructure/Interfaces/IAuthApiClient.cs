using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Smtp;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface IAuthApiClient
    {
        public Task<ApiResult<LoginResponseDto>?> TokenAsync(LoginRequestDto model, CancellationToken ct);

        public Task<ApiResult<Response<SmtpResponseDto>?>> SendOtpAsync(OtpRequestDto model,CancellationToken ct);
        public Task<ApiResult<Response<OtpResponseDto>?>> CheckOtpAsync(OtpRequestDto model,CancellationToken ct);
        public Task<ApiResult<Response<RegisterResponseDto>?>> RegisterAsync(RegisterRequestDto model,CancellationToken ct);
        public Task<ApiResult<Response<ResetPasswordResponseDto>?>> ResetPasswordAsync(ResetPasswordRequestDto model,CancellationToken ct);
        public Task<ApiResult<Response<bool>>> CheckExistsCustomer(CheckCustomerDto model, CancellationToken ct);
    }
}
