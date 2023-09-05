
using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Reposiotories;

namespace Persistence;

public static class PersistanceConfigurationService{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext< ProductHubDbContext > (options => {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReposiotry<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
    
}