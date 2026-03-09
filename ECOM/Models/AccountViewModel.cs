using ECOM.Data;

namespace ECOM.Models
{
    public class AccountViewModel
    {
        public Customers? Customers { get; set; }
        public List<OrderHistory>? Orders { get; set; }
        public List<Favorites>? Favorites { get; set; }
        public List<DCoupon>? Coupons { get; set; }
    }
}
