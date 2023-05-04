using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Infrastructure.Persistence.Repositories.JournalEntries
{
    public class JournalEntryRepositoryRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IJournalEntryRepository, JournalEntryRepository>();
        }
    }
}
