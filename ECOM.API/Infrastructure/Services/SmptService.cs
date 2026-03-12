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

        public Task<Response<SmtpResponseDto>> SendEmailAsync(SmtpRequestDto model)
        {
            return Task.Run(() =>
            {
                var response = new Response<SmtpResponseDto>();
                try
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(model.From ?? string.Empty),
                        Subject = model.Subject ?? string.Empty,
                        Body = string.Empty
                    };
                    if (model.Recipients != null)
                    {
                        foreach (var recipient in model.Recipients)
                        {
                            mailMessage.To.Add(recipient);
                        }
                    }
                    if (model.Attachments != null)
                    {
                        foreach (var attachment in model.Attachments)
                        {
                            mailMessage.Attachments.Add(attachment);
                        }
                    }
                    _smtpClient.Send(mailMessage);
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
            });
        }
    }
}
