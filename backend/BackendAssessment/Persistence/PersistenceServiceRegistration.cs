﻿using Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories;
using Persistence.Repository;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductHubDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("SocialSyncDbConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        return services;
    } 
}