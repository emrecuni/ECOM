using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Product
    {
        [Key]
        [Column("Id")]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int BrandId { get; set; }
        public string? Description { get; set; }
        public int SupCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public float Score { get; set; }
        public DateTime AdditionTime { get; set; }
    }
}
