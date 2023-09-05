using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;

namespace Persistence
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApi")).AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetConnectionString("ProductHub");
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}