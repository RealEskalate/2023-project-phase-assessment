using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class ProductListignServiceDbFactory : IDesignTimeDbContextFactory<ProductListingServiceDbContext>
{
    public ProductListingServiceDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ProductListingServiceDbContext>();
        var connectionString = configuration.GetConnectionString("SocialSyncDatabase");

        builder.UseNpgsql(connectionString);

        return new ProductListingServiceDbContext(builder.Options);
    }
}