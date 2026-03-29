using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class GetCouponsResponseDto
    {
        public int CustomerId { get; set; }
        public List<CouponResponseDto>? Coupons { get; set; }
    }
}
