using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class CouponResponseDto
    {
        public int DCouponId { get; set; }
        public int SCouponId { get; set; }
        public string Code { get; set; } = null!;
        public bool Enable { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LowerLimit { get; set; }
        public DateTime? ValidityDate { get; set; }
        public DateTime? DefinitaionDate { get; set; }
    }
}
