using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;

using Application.Exceptions;
using Application.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Domain.Entities;

namespace Persistence.Service;

public class AuthService : IAuthService {
    
     private readonly UserManager<ApplicaionUser> _userManager;
     private readonly SignInManager<ApplicaionUser> _signInManager;
     private readonly RoleManager<ApplicationRole> _roleManager;
     private readonly JwtSetting _jwtSettings; 
    
     public AuthService(UserManager<ApplicaionUser> userManager,SignInManager<ApplicaionUser> signInManager, IOptions<JwtSetting> jwtSettings) 
     { 
         _userManager = userManager; 
         _signInManager = signInManager; 
         _jwtSettings = jwtSettings.Value; 
          
     } 
     
     public async Task<AuthResponse> Login(LoginRequest request) 
     {
         var user = await _userManager.FindByEmailAsync(request.Email);
         
         if (user is null)
         {
             throw new NotFoundException(nameof(user), request.Email);
         }

         var isCorrect = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, isPersistent: true, lockoutOnFailure: false);
         if (!isCorrect.Succeeded)
         {
             throw new BadRequestException($"Invalid credentials for user: {request.Email}");
         }

         string userId = user.Id;
         var roles = await _userManager.GetRolesAsync(user);
         var role = roles.FirstOrDefault();
         var authResponse = new AuthResponse
         {
             Id = userId,
             Email = user.Email,
             Username = user.UserName,
         };
         JwtSecurityToken token = await GenerateToken(authResponse);
         var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
         authResponse.Token = tokenString;

         return authResponse;

     } 
     
     public async Task<AuthResponse> Register(RegisterRequest request) 
     {
         var alreadyExistEmail = await _userManager.FindByEmailAsync(request.Email);
         var alreadyExistUsername = await _userManager.FindByNameAsync(request.UserName);

         if (alreadyExistEmail is not null) throw new BadRequestException("Email already used");
         if (alreadyExistUsername is not null) throw new BadRequestException("Username already used");
         
         var user = new ApplicaionUser
         {
             Email = request.Email,
             UserName = request.UserName,
             EmailConfirmed = true
         };

         // Create the user
         var creatingUser = await _userManager.CreateAsync(user, request.Password);
         if (!creatingUser.Succeeded)
         {
             throw new BadRequestException($"Failed to create user. Check your password.");
         }
         if (await _roleManager.RoleExistsAsync("USER") == false)
         {
             Console.WriteLine("Role Not Found ------------- Role");
             await _roleManager.CreateAsync(new ApplicationRole{Name = "USER"});
             await _roleManager.CreateAsync(new ApplicationRole{Name = "ADMIN"});
         }
         // Add the user to the desired role
         var addToRoleResult = await _userManager.AddToRoleAsync(user, "USER");
         if (!addToRoleResult.Succeeded)
         {
             throw new BadRequestException($"Failed to assign role to the user.");
         }

         return await this.Login( new LoginRequest { Email = request.Email, Password = request.Password });


     }
     private async Task<JwtSecurityToken> GenerateToken(AuthResponse response){
         var claims = new[]{
             new Claim("id", response.Id),
             new Claim("username", response.Username),
             new Claim("email", response.Email),
             new Claim("role", response.Role),
         };
         var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)); 
         var credentialsHashs = new SigningCredentials(ssk,SecurityAlgorithms.HmacSha256); 
     
         var jwtToken = new JwtSecurityToken( 
             issuer: _jwtSettings.Issuer, 
             audience: _jwtSettings.Audience, 
             claims: claims, 
             expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes), 
             signingCredentials: credentialsHashs 
         );
         return jwtToken;
     }

     public async Task<AuthResponse> TokenValidator(string token){
         var tokenHandler = new JwtSecurityTokenHandler();
         var jwtToken = tokenHandler.ReadJwtToken(token);
    
         // Get the values of the claims
         var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
         var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
         var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
         var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
         
         if (id is null || username is null || email is null || role is null)
         {
             throw new BadRequestException("Invalid token");
         }
         
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
            {
                throw new BadRequestException("Invalid token");
            }
    
         // Create and return an AuthResponse object with the claim values
         var authResponse = new AuthResponse
         {
             Id = id,
             Username = username,
             Email = email,
             Role = role
         };
         return authResponse;
        
     }
     
     public async Task<string> GetUserRole(string id){
         var user = await _userManager.FindByIdAsync(id);
         // if (user == null)
         // {
         //     throw new NotFoundException(n,$"User with ID {id} not found.");
         // }
         var roles = await _userManager.GetRolesAsync(user);
         if (roles == null || roles.Count == 0)
         {
             throw new NotFoundException(nameof(ApplicaionUser),$"No roles found for user with ID {id}.");
         }
         return roles[0];
     }

     // public async Task<bool> Update(UpdateUserDTO request, string prevEmail){
     //     
     //     var user = await _userManager.FindByEmailAsync(prevEmail);
     //     user.Email = request.Email;
     //     user.UserName = request.UserName; 
     //     var result = await _userManager.UpdateAsync(user);
     //     return result.Succeeded;
     // }
     
}