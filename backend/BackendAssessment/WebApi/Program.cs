using Application;
using Persistence;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

AddSwaggerDoc(builder.Services);
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

using var scope = builder.Services.BuildServiceProvider().CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
ConfigureRoles(roleManager);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuration
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); 
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


void AddSwaggerDoc(IServiceCollection services) 
{ 
    services.AddSwaggerGen(c => 
    { 
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        { 
            Description = @"JWT Authorization header using the Bearer scheme.  
                      Enter 'Bearer' [space] and then your token in the text input below. 
                      Example: 'Bearer 12345abcdef'", 
            Name = "Authorization", 
            In = ParameterLocation.Header, 
            Type = SecuritySchemeType.ApiKey, 
            Scheme = "Bearer" 
        }); 
 
        c.AddSecurityRequirement(new OpenApiSecurityRequirement() 
        { 
            { 
                new OpenApiSecurityScheme 
                { 
                    Reference = new OpenApiReference 
                    { 
                        Type = ReferenceType.SecurityScheme, 
                        Id = "Bearer" 
                    }, 
                    Scheme = "oauth2", 
                    Name = "Bearer", 
                    In = ParameterLocation.Header, 
 
                }, 
                new List<string>() 
            } 
        }); 
 
        c.SwaggerDoc("v1", new OpenApiInfo 
        { 
            Version = "v1", 
            Title = "ProductHub API", 
 
        }); 
 
    }); 
}

void ConfigureRoles(RoleManager<IdentityRole> roleManager)
{
    if (!roleManager.RoleExistsAsync("User").Result)
    {
        var userRole = new IdentityRole("User");
        roleManager.CreateAsync(userRole).Wait();
    }

    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        var adminRole = new IdentityRole("Admin");
        roleManager.CreateAsync(adminRole).Wait();
    }
}
