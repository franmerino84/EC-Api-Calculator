using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.Additions
{
    public class AdditionCalculationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IAdditionCalculationFormatter, AdditionCalculationFormatter>();
        }
    }
}
