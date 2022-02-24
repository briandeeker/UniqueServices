using Template.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Template.DAL.Context
{
    public class TemplateDbContext : DbContext
    {
        public DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TemplateDB;");
        }
    }
}
