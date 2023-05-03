﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Infrastructure.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handling {RequestType}", typeof(TRequest).Name);
            var response = await next();
            _logger.LogDebug("Handled {ResponseType}", typeof(TResponse).Name);

            return response;
        }
    }
}
