using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Payment
{
    public class CallbackResponseDto
    {
        public string? PaymentStatus { get; set; }
        public string? PaymentId { get; set; }
        public string? ResultMessage { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorGroup { get; set; }
        public string? ErrorMessage { get; set; }
        public decimal Price { get; set; }
    }
}
