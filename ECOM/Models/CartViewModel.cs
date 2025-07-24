using ECOM.Data;

namespace ECOM.Models
{
    public class CartViewModel
    {
        public List<Cart> Carts { get; set; } = [];
        public List<Favorites> Favorites { get; set; } = [];
    }
}
