using System.Net.Mail;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;

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
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(model.From ?? string.Empty),
                    Subject = model.Subject ?? string.Empty,
                    Body = model.Body ?? string.Empty,
                    IsBodyHtml = model.IsBodyHtml
                };
                if (model.Recipients != null)
                {
                    foreach (var recipient in model.Recipients)
                        mailMessage.To.Add(recipient);
                }
                if (model.Attachments != null)
                {
                    foreach (var attachment in model.Attachments)
                        mailMessage.Attachments.Add(attachment);
                }
                await _smtpClient.SendMailAsync(mailMessage);
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
