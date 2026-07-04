using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Payment;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface IPaymentService
    {
        public Task<Response<PaymentResponseDto>> Pay(PaymentRequestDto model);
        public Task<Response<CallbackResponseDto>> CallBack(IFormCollection form);
    }
}
