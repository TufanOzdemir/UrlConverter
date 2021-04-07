using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using UrlShortener.Domain.Logging;

namespace UrlShortener.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogService logService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException)
            {
                var exModel = new GeneralError { Message = "Not Authenticated", Status = HttpStatusCode.Unauthorized };
                await ContextDecorator(context, exModel);
            }
            catch (AuthenticationException)
            {
                var exModel = new GeneralError { Message = "Not Authorized", Status = HttpStatusCode.Forbidden };
                await ContextDecorator(context, exModel);
            }
            catch (ValidationException)
            {
                var exModel = new GeneralError { Message = "ValidationException", Status = HttpStatusCode.BadRequest };
                await ContextDecorator(context, exModel);
            }
            catch (Exception ex)
            {
                var exModel = new GeneralError { Message = "An error occurred", Status = HttpStatusCode.InternalServerError };
                _logService.Error(ex.Message, ex);
                await ContextDecorator(context, exModel);
            }
        }

        private async Task ContextDecorator(HttpContext context, GeneralError error)
        {
            context.Response.Clear();
            context.Response.ContentType = "json";
            context.Response.StatusCode = error.Status.GetHashCode();
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }

    public class GeneralError
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }

    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}