using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Product
    {
        [Key]
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
        public DateTime? AdditionTime { get; set; }

        //navigation property
        public Brand Brand { get; set; } = null!;
        public ProductCategories SupCategory { get; set; } = null!;
        public ProductCategories SubCategory { get; set; } = null!;
        public Seller Seller { get; set; } = null!;

        // reverse navigation property
        public ICollection<Cart> Carts { get; set; } = [];
        public ICollection<Favorites> Favorites { get; set; } = [];
        public ICollection<OrderHistory> Orders { get; set; } = [];
        public ICollection<Comments> Comments { get; set; } = [];
    }
}
