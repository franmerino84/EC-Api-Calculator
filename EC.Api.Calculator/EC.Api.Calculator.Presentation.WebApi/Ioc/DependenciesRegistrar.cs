using EC.Api.Calculator.Domain.Ioc;

namespace EC.Api.Calculator.Presentation.WebApi.Ioc
{
    public static class DependenciesRegistrar
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddApiDependencies();
            services.AddDomainDependencies();
            return services;
        }
    }
}