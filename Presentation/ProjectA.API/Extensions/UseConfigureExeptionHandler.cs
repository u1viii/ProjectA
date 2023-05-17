using Microsoft.AspNetCore.Diagnostics;
using ProjectA.Application.Exceptions;
using System;
using System.Net.Mime;
using System.Text.Json;

namespace ProjectA.API.Extensions
{
    public static class UseConfigureExeptionHandler
    {
        public static void UseConfigureExceptionHandler<T>(this WebApplication app, ILogger<T> logger)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    if (contextFeatures != null)
                    {
                        //TODO: switch-case`e cevir
                        int statusCode = 500;
                        string message = String.Empty;
                        if (contextFeatures.Error is IBaseException customEx)
                        {
                            statusCode = customEx.StatusCode;
                            message = customEx.ErrorMessage;
                        }
                        else if (contextFeatures.Error is InvalidOperationException)
                        {
                            statusCode = 400;
                            message = contextFeatures.Error.Message ?? contextFeatures.Error.InnerException?.Message ??"Bad Request";
                        }
                        else if (contextFeatures.Error is ArgumentNullException)
                        {
                            statusCode = 400;
                            message = contextFeatures.Error.Message ?? contextFeatures.Error.InnerException?.Message ?? "Argument is null";
                        }
                        else
                        {
                            message = contextFeatures.Error.Message ?? contextFeatures.Error.InnerException?.Message ?? "Bad Request";
                        }
                        context.Response.StatusCode = statusCode;
                        logger.LogError(message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = statusCode,
                            ErrorMessage = message,
                            Title = "Gozlenilmez xeta bash verdi"
                        }));
                    }
                });
            });
        }
    }
}
