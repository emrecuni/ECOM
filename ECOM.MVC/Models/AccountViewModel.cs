using ECOM.MVC.OldFiles.Data;
using ECOM.Shared.Data.DTOs.Customer;

namespace ECOM.Models
{
    public class AccountViewModel
    {
        public BasicCustomerResponseDto? Customers { get; set; }
        public List<OrderDto>? Orders { get; set; }
        public List<Favorites>? Favorites { get; set; }
        public List<CouponResponseDto>? Coupons { get; set; }
    }
}
