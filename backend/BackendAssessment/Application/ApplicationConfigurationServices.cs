using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;


namespace Application;

public static class ApplicationConfigurationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }

}