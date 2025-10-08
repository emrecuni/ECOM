using ECOM.Models;

namespace ECOM.Interface
{
    public interface ISmtp_Sender
    {
        bool SendMail(EmailContent content);
    }
}
