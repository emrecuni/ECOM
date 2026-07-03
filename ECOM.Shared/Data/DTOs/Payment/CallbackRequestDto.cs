using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ECOM.Shared.Data.DTOs.Payment
{
    public class CallbackRequestDto
    {
        public IFormCollection? Form { get; set; }
        public int CustomerId { get; set; }
    }
}
