using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Middleware;

public class ApiExceptionHandler(
    ProblemDetailsFactory problemDetailsFactory
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problem = new ProblemDetails
        {
            Instance = httpContext.Request.Path,
            Detail = exception.Message,
        };

        switch (exception)
        {
            case InputValidationException badRequestException:
                problem.Status = (int)HttpStatusCode.BadRequest;

                foreach (var validationResult in badRequestException.Errors)
                {
                    problem.Extensions.Add(validationResult.Key, validationResult.Value);
                }
                break;
            case NotFoundException notFoundException:
                problem.Status = (int)HttpStatusCode.NotFound;
                break;
            default:
                problem.Status = (int)HttpStatusCode.InternalServerError;
                break;
        }

        ProblemDetails problemDetails;

        if (problemDetailsFactory != null)
        {
            problemDetails = problemDetailsFactory.CreateProblemDetails(
                httpContext, statusCode: problem.Status
            );
            problem.Title = problemDetails.Title;
            problem.Type = problemDetails.Type;
        }

        var result = new ObjectResult(problem)
        {
            StatusCode = problem.Status
        };

        var response = JsonConvert.SerializeObject(result.Value);
        httpContext.Response.ContentType = "application/problem+json";
        await httpContext.Response.WriteAsync(response, cancellationToken);

        return true;
    }
}
