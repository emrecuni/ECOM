using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Entities;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class CartResponseDto
    {
        public List<ProductOfCartDto>? Products { get; set; }
        public int TotalPiece { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
