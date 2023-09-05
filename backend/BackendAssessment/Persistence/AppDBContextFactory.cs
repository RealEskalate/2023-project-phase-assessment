using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApi")).AddJsonFile("appsettings.json").Build();

        var connectionString = config.GetConnectionString("DbConnectionString");
        var builder = new DbContextOptionsBuilder<AppDBContext>();
        builder.UseNpgsql(connectionString);

        return new AppDBContext(builder.Options);
    }
}