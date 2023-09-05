using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Data;

namespace Persistence
{
    public class ApiDBContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApi")).AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<ApiDbContext>();
            builder.UseNpgsql(connectionString);
            return new ApiDbContext(builder.Options);
        }
    }
}