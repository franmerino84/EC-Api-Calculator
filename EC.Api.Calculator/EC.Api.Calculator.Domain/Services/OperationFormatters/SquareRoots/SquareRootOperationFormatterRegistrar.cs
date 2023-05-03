using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters.SquareRoots
{
    public class SquareRootOperationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<ISquareRootOperationFormatter, SquareRootOperationFormatter>();
        }
    }
}
