namespace ECOM.Interface
{
    public interface ISmtp_Sender
    {
        bool SendMail(string toMail, string subject, string body);
    }
}
