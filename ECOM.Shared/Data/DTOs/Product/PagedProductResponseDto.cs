namespace ECOM.Shared.Data.DTOs.Product
{
    // "daha fazla ürün gör" için sayfalı ürün listesi; sonraki sayfa LastId'den sonraki ürünlerle başlar
    public class PagedProductResponseDto
    {
        public List<BasicProductResponseDto> Products { get; set; } = [];
        public bool HasMore { get; set; }
        public int? LastId { get; set; }
    }
}
