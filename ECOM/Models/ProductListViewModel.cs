using ECOM.Data;

namespace ECOM.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public List<Favorites>? Favorites { get; set; }
    }
}
