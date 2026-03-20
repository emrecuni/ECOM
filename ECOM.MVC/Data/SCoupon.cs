using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class SCoupon
    {
        [Key]
        public int SCouponId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LowerLimit { get; set; }
        public DateTime? ValidityDate { get; set; }

        // reverse navigation property
        public ICollection<DCoupon> Coupons { get; set; } = [];
    }
}
