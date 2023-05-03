using EC.Api.Calculator.Infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters.Additions
{
    public class AdditionOperationFormatterRegistrar : IDependenciesRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IAdditionOperationFormatter, AdditionOperationFormatter>();
        }
    }
}
