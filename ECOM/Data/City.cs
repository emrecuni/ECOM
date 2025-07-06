using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? Name { get; set; }

        public ICollection<Addresses> CityOfAddress { get; set; } = [];
    }
}
