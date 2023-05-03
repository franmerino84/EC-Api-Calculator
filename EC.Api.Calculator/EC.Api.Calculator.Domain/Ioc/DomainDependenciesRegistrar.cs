using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Ioc
{
    public static class DomainDependenciesRegistrar
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddDependenciesFromAssemblyOfType<JournalEntry>();

            return services;
        }
    }
}
