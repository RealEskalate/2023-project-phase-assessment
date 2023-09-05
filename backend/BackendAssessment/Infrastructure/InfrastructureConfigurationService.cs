using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Contracts.Identity;
using Application.Model;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Service;

namespace Persistence
{ 
    public static class InfrastuctureServices 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) { 
            
            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting")); 
 
            services.AddDbContext<AuthIdentityDbContext>(options => {
                    options.UseNpgsql(configuration.GetConnectionString("ProductHub"));
                }
            ); 
 
            services.AddIdentity<ApplicaionUser, IdentityRole>().AddEntityFrameworkStores<AuthIdentityDbContext>().AddDefaultTokenProviders();
            services.AddIdentity<ApplicationRole, IdentityUser>().AddEntityFrameworkStores<AuthIdentityDbContext>().AddDefaultTokenProviders(); 


            services.AddTransient<IAuthService, AuthService>(); 
 
            services.AddAuthentication( 
                options => 
                 { 
                     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
                 } 
                ).AddJwtBearer( 
                        o => { 
 
                            o.TokenValidationParameters = new TokenValidationParameters 
                            { 
 
                                ValidateIssuerSigningKey = true, 
                                ValidateIssuer = true, 
                                ValidateAudience = true, 
                                ValidateLifetime = true, 
                                ClockSkew = TimeSpan.Zero, 
                                ValidIssuer = configuration["JwtSetting:Issuer"], 
                                ValidAudience = configuration["JwtSetting:Audience"], 
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"])) 
                            }; 
 
 
                        } 
                ); 
 
            return services; 
 
     
        } 
    } 
}