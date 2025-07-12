using ECOM.Data;
using ECOM.Interface;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECOM.Services
{
    public class Smtp_Sender : ISmtp_Sender
    {
        public bool SendMail(string toMail)
        {
			try
			{
                SmtpClient client = new();
                MailMessage message = new();

                //mail gönderecek smtp ayarları yapılır
                client.Credentials = new NetworkCredential("cuniiemre@gmail.com", "#S");
                client.Port = 587;
                client.Host = "smtp-mail.outlook.com";
                client.EnableSsl = true;

                // mail içeriği hazırlanır
                message.To.Add(toMail);
                message.From = new MailAddress("cuniiemre@gmail.com");
                message.Subject = "Parola Yenileme";
                message.Body = "Parola Yenileme İçin Aşağıdaki Linke Tıklayınız.";

                client.Send(message); // mail gönderilir

                return true;
			}
			catch (Exception ex)
			{
                NLogger.logger.Error($"SendMail Error => {ex}");
                return false;
			}
        }
    }
}
