using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public int? DCouponId { get; set; }
        public int? Piece { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? Enable { get; set; }

        // navigation property
        public Product Product { get; set; } = null!;
        public Customers Customer { get; set; } = null!;
        public Seller Seller { get; set; } = null!;
        public DCoupon? Coupon { get; set; }
    }
}
