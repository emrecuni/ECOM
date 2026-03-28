using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class SearchProductByNameRequestDto
    {
        public string ProductName { get; set; } = null!;
        public int CustomerId { get; set; }
    }
}
