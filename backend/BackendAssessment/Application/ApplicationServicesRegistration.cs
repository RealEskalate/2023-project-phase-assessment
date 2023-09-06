using System.Reflection;
using Application.Features.Product.Handlers.Queries;
using Application.Features.Product.Requests.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration {
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //  services.AddMediatR(Assembly.GetAssembly(typeof(GetProductsRequestHandler)));
         services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
