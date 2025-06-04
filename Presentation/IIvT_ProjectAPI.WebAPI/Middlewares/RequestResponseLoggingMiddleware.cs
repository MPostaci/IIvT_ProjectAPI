using System.Diagnostics;

namespace IIvT_ProjectAPI.WebAPI.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;

            _logger.LogInformation(
                "HTTP {Method} {Path}{QueryString}",
                request.Method,
                request.Path,
                request.QueryString
                );

            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(httpContext);

                stopwatch.Stop();

                var statusCode = httpContext.Response.StatusCode;
                _logger.LogInformation(
                    "HTTP {Method} {Path} responded {StatusCode} in {Elapsed}ms",
                    request.Method,
                    request.Path,
                    statusCode,
                    stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(
                    ex,
                    "HTTP {Method} {Path} threw {Exception} in {Elapsed}ms",
                    request.Method,
                    request.Path,
                    ex.GetType().Name,
                    stopwatch.ElapsedMilliseconds);

                throw;
            }
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
