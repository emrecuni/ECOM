using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.API.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        // özük bilgilerini değiştirecek metodu yaz (ad-soyad, doğum tarihi cinsiyet)

        // iletişim bilgilerini değiştirecek metodu yaz (telefon, eposta) // eposta güncellenirken doğrulama iste ?? eskisine mi yenisine mi

        // parola değiştirecek metodu yaz (eski parolayı da iste) ?? auth'a mı yazılmalı

        
        // müşterinin kuponlarını çekecek metodu yaz

        // 
        public Task<Response<string>> AddFavorite(FavoriteRequestDto model);
        public Task<Response<string>> RemoveFavorite(FavoriteRequestDto model);
        public Task<Response<List<BasicProductResponseDto>>> GetFavorites(int customerId);
    }
}
