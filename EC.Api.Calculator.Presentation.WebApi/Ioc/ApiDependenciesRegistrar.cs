using EC.Api.Calculator.Application.Calculators.Commands.Additions;
using EC.Api.Calculator.Infrastructure.Logging;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Configuration.OutputFormatters;
using MediatR;
using NLog.Extensions.Logging;



namespace EC.Api.Calculator.Presentation.WebApi.Ioc
{
    public static class ApiDependenciesRegistrar
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());   
                })
                .ConfigureApiBehaviorOptions(options=>
                {
                    options.InvalidModelStateResponseFactory = context =>
                        context.GetDefaultInvalidDataModelUnprocessableEntityObjectResult();                        
                });

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
