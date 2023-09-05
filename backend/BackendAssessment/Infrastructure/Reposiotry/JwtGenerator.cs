using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Reposiotry;
public class JwtGenerator : IJwtGenerator
{
    

    public Task<string> CreateToken(User user)
    {

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("4A7F9D8C3E6B025F1A4D763CACB2E832A6E9D6F591B6322A54CE33D25773E45B"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Username),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var secuirtyToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signingCredentials,
            issuer: "localhost", 
            audience: "localhost"
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(secuirtyToken));
    }
}