using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ECOM.Shared.Data.DTOs
{
    public class SmtpRequestDto
    {
        public string? From { get; set; }
        public List<string>? Recipients { get; set; }
        public string? Subject { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
