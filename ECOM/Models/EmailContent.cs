namespace ECOM.Models
{
    public class EmailContent
    {
        public string ToMail { get; set; } = null!;
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int Expire { get; set; }
    }
}
