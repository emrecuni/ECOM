using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Payment
{
    public class PaymentRequestDto
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
    }
}
