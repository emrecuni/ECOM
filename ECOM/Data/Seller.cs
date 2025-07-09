using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string? Name { get; set; }
        public float Score { get; set; }
        public DateTime AdditionTime { get; set; }

        // reverse navigation property
        public ICollection<Cart> Carts { get; set; } = [];
        public ICollection<OrderHistory> Orders { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
    }
}
