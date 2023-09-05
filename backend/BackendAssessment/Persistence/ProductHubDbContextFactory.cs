using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ProductHubDbContextFactory : IDesignTimeDbContextFactory<ProductHubDbContext>
    {
        public ProductHubDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../WebApi")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ProductHubDbContext>();
            var connectionString = configuration.GetConnectionString("ProductHub");

            builder.UseNpgsql(connectionString);
            builder.EnableSensitiveDataLogging();


            return new ProductHubDbContext(builder.Options);

        }
    }
}
