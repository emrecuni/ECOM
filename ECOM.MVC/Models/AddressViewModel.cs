using ECOM.Shared.Data.DTOs.Customer;
using ECOM.Shared.Data.DTOs.Location;
using ECOM.Shared.Data.DTOs.Product;

namespace ECOM.Models
{
    public class AddressViewModel
    {
        public List<AddressDetailDto> Addresses { get; set; } = [];
        public CartResponseDto? Cart { get; set; }
        public List<CityDto> Cities { get; set; } = []; // ilçe ve mahalleler şehir seçilince ajax ile yüklenir
    }
}
