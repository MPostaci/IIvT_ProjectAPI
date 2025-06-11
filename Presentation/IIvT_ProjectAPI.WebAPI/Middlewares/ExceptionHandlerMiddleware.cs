using IIvT_ProjectAPI.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int status;
            ProblemDetails problem;

            switch (ex)
            {
                case NotFoundException nf:
                    status = StatusCodes.Status404NotFound;
                    problem = new ProblemDetails
                    {
                        Title = "Not Found",
                        Detail = nf.Message,
                        Status = status
                    };
                    break;

                case BadHttpRequestException badReq:
                    status = badReq.StatusCode;
                    problem = new ProblemDetails
                    {
                        Title = "Bad Request",
                        Detail = badReq.Message,
                        Status = status
                    };
                    break;

                default:
                    status = StatusCodes.Status500InternalServerError;
                    problem = new ProblemDetails
                    {
                        Title = "An unexpected error occurred",
                        Status = status
                    };
                    break;
            }

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";
            return JsonSerializer.SerializeAsync(context.Response.Body, problem);
        }
    }
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
