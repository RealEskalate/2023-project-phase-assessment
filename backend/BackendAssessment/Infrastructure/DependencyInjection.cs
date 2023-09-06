using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Common.Interface.Authentication;
using Infrastructure.Authentication;
using Application.Common.Interface.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Infrastructure.Mail;
using Application.Services.Authentication;
using Infrastructure.Authentication.Services;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuth(configuration);
            // services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IJwtTokenValidation, JwtTokenValidation>();
            services.AddScoped<IPasswordHashService, PasswordHashService>();

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