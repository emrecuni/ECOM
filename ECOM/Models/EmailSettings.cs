namespace ECOM.Models
{
    public class EmailSettings
    {
        public string? SenderMail { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public string?  Host { get; set; }
        public bool SSL { get; set; }        
    }
}
