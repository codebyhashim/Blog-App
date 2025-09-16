using System.Text.Json.Serialization;
using Application.model.ResponseWrapper;
using Domain.Constants;
using System.Text.Json;
namespace BlogApi.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;
        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
                catch (Exception ex)
                {
                    var routData = context.GetRouteData();
                    var controller = routData.Values["controller"]?.ToString() ?? "unknown controller";
                    var action = routData.Values["action"]?.ToString() ?? "unknown action";
                    _logger.LogError(ex," An unhandled exception has occurred while processing the request.controller: {Controller} action : {Action}", controller,action);
                    //context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResult()
                {
                    Error=new List<ErrorDto>()
                    {
                        new ErrorDto()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message=ex.Message
                        }
                    }
                }));
                    
            }
        }


    }
}
