using EC.Api.Calculator.Domain.Services.OperationFormatters;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.Subtractions
{
    public class SubtractionCalculationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<ISubtractionCalculationFormatter, SubtractionCalculationFormatter>();
        }
    }
}
