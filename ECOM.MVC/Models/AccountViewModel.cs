using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.Models
{
    public class AccountViewModel
    {
        public BasicCustomerResponseDto? Customers { get; set; }
        public List<OrderDto> Orders { get; set; } = [];
        public List<BasicProductResponseDto> Favorites { get; set; } = [];
        public List<CouponResponseDto> Coupons { get; set; } = [];
    }
}
