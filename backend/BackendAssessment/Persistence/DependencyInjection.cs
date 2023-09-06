using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Data;
// using Application.Common.Interface.Authentication;
// using Infrastructure.Authentication;
// using Application.Common.Interface.Services;
// using Infrastructure.Services;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.Extensions.Options;
// using System.Text;
// using Infrastructure.Mail;
// using Application.Services.Authentication;
// using Infrastructure.Authentication;
using Application.Contracts;
using Infrastructure.Persistence.Repositories.UserRepo;
using Persistence.Repositories.ProductRepo;
using Persistence.Repositories.CategoryRepo;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}

        