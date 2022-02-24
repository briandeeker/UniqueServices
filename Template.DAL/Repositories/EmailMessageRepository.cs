using Template.DAL.Context;
using Template.DAL.Entities;

namespace Template.DAL.Repositories
{
    public class EmailMessageRepository : IEmailMessageRepository
    {
        protected readonly TemplateDbContext _context;

        public EmailMessageRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailMessage emailMessage)
        {
            await _context.Set<EmailMessage>().AddAsync(emailMessage);
            await _context.SaveChangesAsync();
        }
    }
}
