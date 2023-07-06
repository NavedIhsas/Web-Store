using Microsoft.AspNetCore.Builder;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Domain.Exception
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }



    //public static class ExceptionMiddlewareExtensions
    //{
    //    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    //    {
    //        app.U.UseExceptionHandler(appError =>
    //        {
    //            appError.Run(async context =>
    //            {
    //                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //                context.Response.ContentType = "application/json";
    //                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
    //                if (contextFeature != null)
    //                {
    //                    logger.LogError($"Something went wrong: {contextFeature.Error}");
    //                    await context.Response.WriteAsync(new ErrorDetails()
    //                    {
    //                        StatusCode = context.Response.StatusCode,
    //                        Message = "Internal Server Error."
    //                    }.ToString());
    //                }
    //            });
    //        });
    //    }
    //}
}
