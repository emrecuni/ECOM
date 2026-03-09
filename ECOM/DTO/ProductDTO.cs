using ECOM.Data;

namespace ECOM.DTO
{
    public class ProductDTO 
    {
        public int ProductId { get; set; }
        public string ? BrandName { get; set; }
        public string? SupCategory { get; set; }
        public string? SubCategory { get; set; }
        public string? SellerName { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public float? Score { get; set; }
        public string? ImagePath { get; set; }
        public bool IsFavorite { get; set; }
    }
}
