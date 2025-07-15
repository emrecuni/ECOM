using ECOM.Data;

namespace ECOM.Models
{
    public class ProductDetailViewModel
    {
        public Product? Product { get; set; }
        public List<Comments> Comments { get; set; } = [];
    }
}
