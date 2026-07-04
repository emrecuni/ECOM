using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Payment
{
    public class PaymentResponseDto
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorGroup { get; set; }
        public string? Content { get; set; }
        // içeriği burda dön hata mesajını da eklE
    }
}
