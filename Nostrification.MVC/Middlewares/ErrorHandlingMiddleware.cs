
using Nostrification.Domain.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nostrification.MVC.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            logger.LogWarning(notFound.Message);
            await WriteResponse(context, HttpStatusCode.NotFound, notFound.Message);
        }
        catch (ConflictException ex)
        {
            logger.LogWarning(ex.Message);
            await WriteResponse(context, HttpStatusCode.Conflict, ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            logger.LogWarning(ex.Message);
            await WriteResponse(context, HttpStatusCode.Unauthorized, ex.Message);
        }
        catch (DomainValidationException ex)
        {
            logger.LogWarning(ex.Message);
            await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (BusinessRuleException ex)
        {
            logger.LogWarning(ex.Message);
            await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (IntegrityException ex)
        {
            logger.LogWarning(ex.Message);
            await WriteResponse(context, HttpStatusCode.InternalServerError, ex.Message);
        }
        catch (Exception e)
        {
            if (context.Response.HasStarted)
            {
                logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
            else
            {
                // response boshlangan bo‘lsa — log qilish kifoya
                logger.LogWarning(e, "Response already started, cannot write error.");
            }
        }
    }

    private Task WriteResponse(HttpContext context, HttpStatusCode status, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        var result = JsonSerializer.Serialize(new
        {
            status = context.Response.StatusCode,
            error = message
        });

        return context.Response.WriteAsync(result);
    }
}
