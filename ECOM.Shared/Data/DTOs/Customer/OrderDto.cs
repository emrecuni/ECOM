using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Enums;

namespace ECOM.Shared.Data.DTOs.Customer
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? CartId { get; set; }
        public OrderStatus Status { get; set; }
        public string? Image { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Price { get; set; }
    }
}
