using System.Net.Mail;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Smtp;
using ECOM.Shared.Data.Enums;

namespace ECOM.API.Infrastructure.Services
{
    public class SmptService : ISmtpService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<SmtpClient> _logger;

        public SmptService(SmtpClient smtpClient, ILogger<SmtpClient> logger)
        {
            _smtpClient = smtpClient;
            _logger = logger;
        }

        public async Task<Response<SmtpResponseDto>> SendEmailAsync(SmtpRequestDto model)
        {
            var response = new Response<SmtpResponseDto>();
            try
            {                
                var mailMessage = new MailMessage // mesaj nesnesi oluşturulur
                {
                    From = new MailAddress(model.From ?? string.Empty),
                    Subject = model.Subject ?? string.Empty,
                    Body = model.Body ?? string.Empty,
                    IsBodyHtml = model.IsBodyHtml
                };
                if (model.Recipients != null) // alıcılar eklenir
                {
                    foreach (var recipient in model.Recipients)
                        mailMessage.To.Add(recipient);
                }
                if (model.Attachments != null) // varsa ekler eklenir
                {
                    foreach (var attachment in model.Attachments)
                        mailMessage.Attachments.Add(attachment);
                }

                await _smtpClient.SendMailAsync(mailMessage); // mail gönderilir

                response.Result = new SmtpResponseDto
                {
                    TotalSendedMailCount = 1,
                    SuccessfulySendedMailCount = 1,
                    FailedSendedMailCount = 0
                };
                response.Status = Status.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                response.Result = new SmtpResponseDto
                {
                    TotalSendedMailCount = 1,
                    SuccessfulySendedMailCount = 0,
                    FailedSendedMailCount = 1
                };
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
