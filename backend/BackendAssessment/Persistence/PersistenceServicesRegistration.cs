using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Persistence.Repositories;


namespace BackendAssessment.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<BackendAssessmentDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConn"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
