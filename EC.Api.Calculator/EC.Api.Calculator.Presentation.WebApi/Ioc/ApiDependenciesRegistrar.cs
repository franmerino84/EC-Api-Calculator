using EC.Api.Calculator.Application.Calculators.Additions;
using EC.Api.Calculator.Infrastructure.Logging;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Configuration.OutputFormatters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog.Extensions.Logging;
using System.Net;

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
                        new UnprocessableEntityObjectResult(
                            new ApplicationErrorBody(
                                ErrorCode.InvalidDataModel, 
                                (int) HttpStatusCode.UnprocessableEntity, 
                                string.Join(" | ",context.ModelState.Values.SelectMany(v => v.Errors).Select(x=>x.ErrorMessage))));                    
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





