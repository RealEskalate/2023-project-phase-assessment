using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public static class PersistenceConfigurationService
    {

        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductHubDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("ProductHub"));
            });

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IPostRepository, PostRepository>();
            //services.AddScoped<IFollowRepository, FollowRepository>();
            //services.AddScoped<ILikeRepository, LikeRepository>();
            return services;
        }

    }
}

