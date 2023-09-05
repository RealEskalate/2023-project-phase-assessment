using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Contracts.Auth;
using Application.DTOs.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence.Repositories.Jwt;

namespace Persistence.Repositories.Auth;

public class AuthRepository : IAuth
{
    private readonly AppDBContext _dbContext;
    private readonly JwtSettings _jwtSettings;
    // private readonly I
    
    public AuthRepository(AppDBContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _jwtSettings = new JwtSettings();
        configuration.GetSection("JwtSettings").Bind(_jwtSettings);
    }
    
    public async Task<string> Login(AuthRequest authRequest)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == authRequest.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(authRequest.Password, user.Password))
        {
            throw new Exception("Password doesn't match");
        }

        var token = JwtTokenGenerator.GenerateToken(user.Email, user.Username, user.Id, (user.IsAdmin)?"Admin" : "User",
            _jwtSettings);

        return token;
    }
}