using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Enums;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class OrderResponseDto
    {
        public int CustomerId { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}
