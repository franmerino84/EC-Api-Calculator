using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.Divisions
{
    public class DivisionCalculationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IDivisionCalculationFormatter, DivisionCalculationFormatter>();
        }
    }
}
