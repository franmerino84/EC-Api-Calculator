using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters.Multiplications
{
    public class MultiplicationOperationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IMultiplicationOperationFormatter, MultiplicationOperationFormatter>();
        }
    }
}
