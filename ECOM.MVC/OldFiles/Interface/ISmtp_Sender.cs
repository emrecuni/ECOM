using ECOM.Models;

namespace ECOM.MVC.OldFiles.Interface
{
    public interface ISmtp_Sender
    {
        bool SendMail(EmailContent content);
    }
}
