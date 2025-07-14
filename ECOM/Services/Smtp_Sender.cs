using ECOM.Data;
using ECOM.Interface;
using ECOM.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECOM.Services
{
    public class Smtp_Sender : ISmtp_Sender
    {
        private readonly IConfiguration _configuration;

        public Smtp_Sender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendMail(string toMail)
        {
            try
            {
                // appsetttings'ten email ayarları okunur
                var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();
                if(emailSettings is not null && emailSettings.SenderMail is not null && emailSettings.Password is not null
                    && emailSettings.Host is not null) // email ayarları null değilse 
                {

                    var client = new SmtpClient("smtp.zoho.com", 465)
                    {
                        EnableSsl = true,
                        UseDefaultCredentials =false,
                        Credentials = new NetworkCredential("info@emrecuni.xyz", "p3zUZzTifbkv")
                    };

                    //SmtpClient client = new();
                    MailMessage message = new();

                    ////mail gönderecek smtp ayarları yapılır
                    //client.Credentials = new NetworkCredential(emailSettings.SenderMail, emailSettings.Password);
                    //client.Port = emailSettings.Port;
                    //client.Host = emailSettings.Host;
                    //client.EnableSsl = emailSettings.SSL;

                    //// mail içeriği hazırlanır
                    message.To.Add(toMail);
                    message.From = new MailAddress(emailSettings.SenderMail);
                    message.Subject = "Parola Yenileme";
                    message.Body = "Parola Yenileme İçin Aşağıdaki Linke Tıklayınız.";

                    client.Send(message); // mail gönderilir

                    return true;
                }
                else // email ayarları null'se
                {

                    return false;
                }
               
            }
            catch (Exception ex)
            {
                NLogger.logger.Error($"SendMail Error => {ex}");
                return false;
            }
        }
    }
}

