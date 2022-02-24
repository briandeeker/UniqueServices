using Template.DAL.Entities;

namespace Template.DAL.Repositories
{
    public interface IEmailMessageRepository
    {
        Task AddAsync(EmailMessage emailMessage);
    }
}
