using ECOM.Data;

namespace ECOM.Models
{
    public class AddressViewModel
    {
        public List<Addresses> Addresses { get; set; } = [];
        public List<Cart> Cart { get; set; } = [];
        public List<City> Cities { get; set; } = [];
        public List<District> Districts { get; set; } = [];
        public List<Neighbourhood> Neighbourhoods { get; set; } = [];
    }
}
