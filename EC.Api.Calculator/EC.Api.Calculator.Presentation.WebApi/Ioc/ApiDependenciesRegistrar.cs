using EC.Api.Calculator.Application.Calculators.Additions;
using EC.Api.Calculator.Infrastructure.Logging;
using MediatR;
using NLog.Extensions.Logging;

namespace EC.Api.Calculator.Presentation.WebApi.Ioc
{
    public static class ApiDependenciesRegistrar
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMappings();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(AdditionCommand).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog(new NLogProviderOptions
                {
                    CaptureMessageProperties = true,
                    CaptureMessageTemplates = true
                });
            });
            return services;
        }
    }
}
