using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            string requestContent = string.Empty;

            try
            {
                requestContent = JsonSerializer.Serialize(request);
            }
            catch
            {
                requestContent = "[Unable to serialize request payload]";
            }

            _logger.LogInformation(
                "----- Handling MediatR request {RequestName}: {RequestContent}",
                requestName,
                requestContent
                );

            var stopwatch = Stopwatch.StartNew();

            try
            {
                var response = await next();

                stopwatch.Stop();

                string responseContent = string.Empty;

                try
                {
                    responseContent = JsonSerializer.Serialize(response);
                }
                catch
                {
                    responseContent = "[Unable to serialize response]";
                }

                _logger.LogInformation(
                    "----- Completed {RequestName} in {ElapsedMilliseconds}ms. Response: {ResponseContent}",
                    requestName,
                    stopwatch.ElapsedMilliseconds,
                    responseContent
                    );

                return response;
            }
            catch ( Exception ex )
            {
                stopwatch.Stop();

                _logger.LogInformation(
                    ex,
                    "----- MediatR request {RequestName} threw an exception after {ElapsedMilliseconds}ms.",
                    requestName,
                    stopwatch.ElapsedMilliseconds
                    );

                throw;
            }
        }
    }
}
