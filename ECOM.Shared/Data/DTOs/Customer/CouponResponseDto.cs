using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class CouponResponseDto
    {
        public int DCouponId { get; set; }
        public int SCouponId { get; set; }
        public int CustomerId { get; set; }
        public bool Enable { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LowerLimit { get; set; }
        public DateTime? ValidityDate { get; set; }
        public DateTime? DefinitaionDate { get; set; }
    }
}
