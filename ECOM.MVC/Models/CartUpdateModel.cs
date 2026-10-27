namespace ECOM.Models
{
    // api sepet satırını cart id ile değil ürün + satıcı ile bulur ve adet ile seçili durumunu birlikte günceller
    public class CartUpdateModel
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int Piece { get; set; }
        public bool Enable { get; set; }
    }
}
