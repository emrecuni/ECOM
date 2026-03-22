using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Product
{
    public class CommentsDto
    {
        public int CommentId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public string? Comment { get; set; }
        public int? Score { get; set; }
        public string? ImagePath { get; set; }
    }
}
