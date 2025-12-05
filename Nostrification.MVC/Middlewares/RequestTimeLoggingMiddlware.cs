
namespace Nostrification.MVC.Middlewares;

public class RequestTimeLoggingMiddlware(Logger<RequestTimeLoggingMiddlware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next.Invoke(context);
    }
}
