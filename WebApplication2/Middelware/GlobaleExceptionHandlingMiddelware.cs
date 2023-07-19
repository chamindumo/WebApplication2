using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;
using System.Text.Json;

namespace WebApplication2.Middelware
{

    public class GlobaleExceptionHandlingMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public GlobaleExceptionHandlingMiddelware(RequestDelegate next,ILogger<GlobaleExceptionHandlingMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); 
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                ProblemDetails details = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Server Error",
                    Detail = "An internal server has occurred"
                };
                var json = JsonSerializer.Serialize(details);
                await context.Response.WriteAsJsonAsync(json);
                context.Response.ContentType = "application/json";





            }
        }
    }
}
