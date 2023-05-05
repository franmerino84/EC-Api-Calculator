using EC.Api.Calculator.Domain.Ioc;
using EC.Api.Calculator.Infrastructure.Persistence.Ioc;

namespace EC.Api.Calculator.Presentation.WebApi.Ioc
{
    public static class DependenciesRegistrar
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddApiDependencies();
            services.AddDomainDependencies();
            services.AddPersistenceDependencies();
            return services;
        }
    }
}