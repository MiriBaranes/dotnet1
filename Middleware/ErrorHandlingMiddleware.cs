using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotnet1.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if (!context.Response.HasStarted && 
                    context.Features.Get<ModelStateDictionary>()?.IsValid == false)
                {
                    var modelState = context.Features.Get<ModelStateDictionary>();
                    await HandleValidationErrorsAsync(context, modelState);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleValidationErrorsAsync(HttpContext context, ModelStateDictionary? modelState)
        {
            if (modelState == null || modelState.IsValid)
            {
                return; 
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = modelState
                .Where(ms => ms.Value != null && ms.Value.Errors.Any())
                .Select(ms => new
                {
                    Field = ms.Key,
                    Errors = ms.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                });

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Validation failed",
                Errors = errors
            };

            _logger.LogWarning("Validation errors occurred: {Errors}", JsonSerializer.Serialize(errorResponse));

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            context.Items["ModelStateHandled"] = true;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Details = exception.InnerException?.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
