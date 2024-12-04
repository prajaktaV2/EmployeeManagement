using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Handling request: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);

            await _next(httpContext);
            stopwatch.Stop();
            _logger.LogInformation("Completed request: {Method} {Path} with status code {StatusCode} in {ElapsedMilliseconds}ms",
                httpContext.Request.Method,
                httpContext.Request.Path,
                httpContext.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
