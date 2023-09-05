using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Application.Contracts;
using Domain.Entites;

namespace Persistence.Repositories
{
    public class AuthenticationRepository : IAuthenticationService
    {
        private readonly ProductHubDbContext _dbContext;

        public AuthenticationRepository(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto)
        {
            try
            {
                var newUser = new User
                {
                    Username = userRegistrationDto.Username,
                    Email = userRegistrationDto.Email,
                    Password = userRegistrationDto.Password
                };

                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();


                string token = GenerateToken(newUser.UserId.ToString());
                return token;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                // Find the user by username or email
                var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
                    u.Username == userLoginDto.UsernameOrEmail || u.Email == userLoginDto.UsernameOrEmail);

                if (user != null && user.Password == userLoginDto.Password)
                {

                    string token = GenerateToken(user.UserId.ToString());
                    return token;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private string GenerateToken(string userId)
        {
            string secretKey = "jossy_backend_assesment";
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
