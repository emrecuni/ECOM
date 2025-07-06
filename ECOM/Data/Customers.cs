using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Data
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
        public bool IsCustomer { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdditionTime { get; set; }

        public ICollection<Addresses> ReceiverAddress { get; set; } = []; // new List<Addresses>()
        public ICollection<Addresses> CustomerAdress { get; set; } = [];

    }
}
