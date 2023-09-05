using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Backend.Infrastructure.Data;
using Backend.Application.Persistence.Contracts;
using Backend.Infrastructure.Persistence.Repositories.UserRepo;
using Backend.Infrastructure.Persistence.Repositories;
using Backend.Application.Common.Interface.Authentication;
using Backend.Infrastructure.Authentication;
using Backend.Application.Common.Interface.Services;
using Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Backend.Infrastructure.Mail;
using Microsoft.VisualBasic;
using Backend.Application.Cloudinary;
using Backend.Application.Services.ImageUpload;
using Backend.Application.Services.Authentication;
using Backend.Infrastructure.Configuration;
using Backend.Application.Services.OpenAI;

namespace Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDbContext>(opt =>
    opt.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuth(configuration);
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IJwtTokenValidation, JwtTokenValidation>();
            
            services.AddScoped<IPasswordHashService, PasswordHashService>();

            // Setup Cloudinary
            services.Configure<CloudinarySettings>(configuration.GetSection(CloudinarySettings.SectionName));
            services.AddTransient<ICloudinaryService, CloudinaryService>();

            // Setup OpenAI
            services.Configure<OpenAIConfig>(configuration.GetSection("OpenAI"));
            services.AddTransient<IOpenAIService, OpenAiService>();

            return services;
        }

        public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
            return services;
        }
    }
}