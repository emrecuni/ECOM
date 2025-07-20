using ECOM.Data;

namespace ECOM.Views.Cart
{
    public class CartViewModel
    {
        public List<Data.Cart> Carts { get; set; } = [];
        public List<Favorites> Favorites { get; set; } = [];
    }
}
