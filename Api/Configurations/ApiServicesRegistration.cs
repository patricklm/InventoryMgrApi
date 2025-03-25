using Api.Exceptions;
using Api.Middleware;

namespace Api.Configurations;

public static class ApiServicesRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        return services;
    }
}
