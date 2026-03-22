using System;
using System.Collections.Generic;
using System.Text;

namespace ECOM.Shared.Data.DTOs.Smtp
{
    public class SmtpResponseDto
    {
        public int TotalSendedMailCount { get; set; }
        public int SuccessfulySendedMailCount { get; set; }
        public int FailedSendedMailCount { get; set; }
    }
}
