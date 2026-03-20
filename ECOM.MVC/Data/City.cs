using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? Name { get; set; }

        // reverse navigation property
        public ICollection<District> Districts { get; set; } = [];
        public ICollection<Addresses> CityOfAddresses { get; set; } = [];
        public ICollection<Neighbourhood> Neighbourhoods { get; set; } = [];
    }
}
