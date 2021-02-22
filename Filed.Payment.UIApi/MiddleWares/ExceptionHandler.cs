using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.UIApi.MiddleWares
{
    internal class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Message:{ex?.Message}|InnerExceptionMessage:{ex?.InnerException?.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal server error ",
            }.ToString());
        }
    }
}
