using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Enums;

namespace ECOM.Shared.Data.DTOs
{
    public sealed class Response<T>
    {
        public T? Result { get;set;  }
        public string? Message { get; set; }
        public Status @Status { get; set; } = Status.Default;
    }
}
