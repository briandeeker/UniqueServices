using Template.DAL.Context;
using Template.DAL.Repositories;
using Template.Services.Implementations;
using Template.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Template.IoC
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IServiceCollection AddTemplateServices(IServiceCollection services)
        {
            return services
                .AddDbContext<TemplateDbContext>()
                .AddScoped<IEmailMessageRepository, EmailMessageRepository>()
                .AddScoped<IEmailService, EmailService>();
        }
    }
}
