using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.Models
{
    public class CartViewModel
    {
        public CartResponseDto? Cart { get; set; } // sepet boşsa null
        public List<BasicProductResponseDto> Favorites { get; set; } = [];
    }
}
