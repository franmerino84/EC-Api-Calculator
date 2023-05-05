using EC.Api.Calculator.Infrastructure.Ioc;
using EC.Api.Calculator.Infrastructure.Persistence.Repositories.JournalEntries;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Infrastructure.Persistence.Ioc
{
    public static class PersistenceDependenciesRegistrar
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddDependenciesFromAssemblyOfType<JournalEntryRepository>();

            return services;
        }
    }
}
