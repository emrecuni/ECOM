using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class DCoupon
    {
        [Key]
        [Column("Id")]
        public int DCouponId { get; set; }
        public int SCouponId { get; set; }
        public int CustomerId { get; set; }
        public bool Enable { get; set; }
        public DateTime DefinitionDate { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
