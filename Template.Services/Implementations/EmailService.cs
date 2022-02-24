using Template.DAL.Repositories;
using Template.Services.Configuration;
using Template.Services.Interfaces;
using Template.Services.Types;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;

namespace Template.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailServerOptions _options;
        private readonly IEmailMessageRepository _emailMessageRepository;

        public EmailService(IOptions<EmailServerOptions> options, IEmailMessageRepository emailMessageRepository)
        {
            _options = options.Value;
            _emailMessageRepository = emailMessageRepository;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect(_options.SmtpServer, _options.SmtpPort, MailKit.Security.SecureSocketOptions.Auto);
                smtp.Authenticate(_options.EmailUsername, _options.EmailPassword);

                var message = CreateMailMessage(emailMessage);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send an email!", ex);
            }
            finally
            {
                // map to entity classes before saving (can also be done with AutoMapper)

                var emailMessageEntity = new DAL.Entities.EmailMessage()
                {
                    FirstName = emailMessage.FirstName,
                    LastName = emailMessage.LastName,
                    Email = emailMessage.EmailAddress,
                    Phone = emailMessage.Phone,
                    Message = emailMessage.Message
                };

                await _emailMessageRepository.AddAsync(emailMessageEntity);
            }
        }

        private MimeMessage CreateMailMessage(EmailMessage emailMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("First name: " + emailMessage.FirstName);
            stringBuilder.AppendLine("Last name: " + emailMessage.LastName);
            stringBuilder.AppendLine("Email: " + emailMessage.EmailAddress);
            stringBuilder.AppendLine("Phone: " + emailMessage.Phone);
            stringBuilder.AppendLine("Message: " + emailMessage.Message);

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_options.EmailUsername));
            message.To.Add(MailboxAddress.Parse(_options.EmailUsername));
            message.Subject = "EmailPages - message from: " + emailMessage.FirstName + " " + emailMessage.LastName;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = stringBuilder.ToString() };

            return message;
        }
    }
}
