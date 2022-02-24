using Template.Services.Types;

namespace Template.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailMessage emailMessage);
    }
}
