using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.JwtTokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(string email, string username, int id)
    {
        // var claims = new[]
        // {
        //     new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
        //     new Claim(JwtRegisteredClaimNames.GivenName, firstname),
        //     new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
        //     new Claim(JwtRegisteredClaimNames.Email, email),
        //     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        // };
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Sid, id.ToString())
        };

        Console.WriteLine(_jwtSettings.Secret);
        Console.WriteLine(_jwtSettings.Audience);
        Console.WriteLine(_jwtSettings.ExpiryDays);
        Console.WriteLine(_jwtSettings.Issuer);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);
        
        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiryDays),
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}