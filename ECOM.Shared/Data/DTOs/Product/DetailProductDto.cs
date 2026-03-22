using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class DetailProductDto
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int SupCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SellerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public float? Score { get; set; }
        public string? ImagePath { get; set; }

        public string? BrandName { get; set; }
        public string? SellerName { get; set; }

    }
}
