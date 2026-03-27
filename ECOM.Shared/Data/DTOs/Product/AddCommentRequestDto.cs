using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class AddCommentRequestDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string? Comment { get; set; }
        public int Score { get; set; }
        public string? ImagePath { get; set; }
    }
}
