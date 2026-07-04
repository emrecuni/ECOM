using System;
using System.Collections.Generic;
using System.Text;
using ECOM.Shared.Data.Enums;

namespace ECOM.Shared.Data.Entities
{
    public class PaymentSession
    {
        public int PaymentSessionId { get; set; }
        public string? ConversationId { get; set; }   // Pay'de ürettiğin Guid
        public string? Token { get; set; }             // iyzico init cevabındaki token
        public int CustomerId { get; set; }
        public decimal ExpectedAmount { get; set; }   // Pay anındaki sepet toplamı
        public PaymentSessionStatus Status { get; set; } // Pending / Completed / Failed
        public string? PaymentId { get; set; }        // Retrieve sonrası doldur
        public DateTime? CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? ProcessingStartedAt { get; set; }
    }
}
