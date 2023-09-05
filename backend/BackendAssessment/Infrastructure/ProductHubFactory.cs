﻿using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class ProductHubFactory: IDesignTimeDbContextFactory<UserIdentityDbContext>
{
    public UserIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<UserIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("ProductHub");

        builder.UseNpgsql(connectionString);

        return new UserIdentityDbContext(builder.Options);
    }
}