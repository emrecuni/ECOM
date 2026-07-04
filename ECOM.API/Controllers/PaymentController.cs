using System.Security.Claims;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs.Payment;
using ECOM.Shared.Data.Entities;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentSevice;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentSevice = paymentService;            
        }

        [Authorize]
        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequestDto model)
        {
            var result = await _paymentSevice.Pay(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Callback")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Callback([FromForm] CallbackRequestDto model)
        {
            var result = await _paymentSevice.CallBack(model.Token);
            return Ok(result);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   