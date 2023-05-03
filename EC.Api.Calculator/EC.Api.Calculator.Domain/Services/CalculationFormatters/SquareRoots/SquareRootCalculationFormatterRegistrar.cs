using EC.Api.Calculator.Domain.Services.OperationFormatters;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.SquareRoots
{
    public class SquareRootCalculationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<ISquareRootCalculationFormatter, SquareRootCalculationFormatter>();
        }
    }
}
