using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ECOM_API.Data.Entity
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public bool Gender { get; set; }
        public bool? IsCustomer { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AdditionTime { get; set; }
    }
}
