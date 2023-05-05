using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Infrastructure.Ioc
{
    public interface IDependenciesRegistrar
    {
        void Register(IServiceCollection services);
    }
}
