using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Seller
    {
        [Key]
        [Column("Id")]
        public int SellerId { get; set; }
        public string? Name { get; set; }
        public float Score { get; set; }
        public DateTime AdditionTime { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
