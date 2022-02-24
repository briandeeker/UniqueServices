using Microsoft.Extensions.DependencyInjection;

namespace Template.IoC
{
    public interface IServiceRegistrar
    {
        IServiceCollection AddTemplateServices(IServiceCollection services);
    }
}
