using System.ComponentModel.DataAnnotations;

namespace ECOM.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }

}
