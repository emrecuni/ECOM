using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Email zorunludur.")]
        [MaxLength(200)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Parola zorunludur.")]
        [MaxLength(50)]
        public string Password { get; set; } = null!;
    }
}
