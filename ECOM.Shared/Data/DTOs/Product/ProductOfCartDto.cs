using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class ProductOfCartDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? ImagePath { get; set; }
        public bool Enable { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
    }
}
