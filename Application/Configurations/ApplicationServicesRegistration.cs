using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ApplicationServicesRegistration).Assembly;

        services.AddMediatR(options => options.RegisterServicesFromAssemblies(applicationAssembly));
        return services;
    }
}
