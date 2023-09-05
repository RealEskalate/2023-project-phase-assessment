using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class ProductHubFactory : IDesignTimeDbContextFactory<ProductHubDbContext>
{
    public ProductHubDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../WebApi")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ProductHubDbContext>();
        var connectionString = configuration.GetConnectionString("ProductHub");

        builder.UseNpgsql(connectionString);

        return new ProductHubDbContext(builder.Options);
    }
}