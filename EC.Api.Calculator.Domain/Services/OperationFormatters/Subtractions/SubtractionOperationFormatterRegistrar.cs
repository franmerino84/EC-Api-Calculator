using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters.Subtractions
{
    public class SubtractionOperationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<ISubtractionOperationFormatter, SubtractionOperationFormatter>();
        }
    }
}
