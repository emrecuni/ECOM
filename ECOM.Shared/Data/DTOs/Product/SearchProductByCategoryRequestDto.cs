using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class SearchProductByCategoryRequestDto
    {
        public int CategoryId { get; set; } 
        public int CustomerId { get; set; }
    }
}
