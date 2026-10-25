using ECOM.MVC.Infrastructure.Models;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Payment;

namespace ECOM.MVC.Infrastructure.Interfaces
{
    public interface IPaymentApiClient
    {
        public Task<ApiResult<Response<PaymentResponseDto>>> PayAsync(PaymentRequestDto model, CancellationToken ct);
        public Task<ApiResult<Response<CallbackResponseDto>>> CallbackAsync(CallbackRequestDto model, CancellationToken ct);
    }
}
