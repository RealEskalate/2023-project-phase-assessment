using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Model;
using Domain.Entities;
using Infrastructure.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Service;

public class AuthService : IAuthService {
    
     private readonly UserManager<ApplicationUser> _userManager;
     private readonly SignInManager<ApplicationUser> _signInManager;
     private readonly JwtSetting _jwtSettings; 
    
     public AuthService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IOptions<JwtSetting> jwtSettings) 
     { 
         _userManager = userManager; 
         _signInManager = signInManager; 
         _jwtSettings = jwtSettings.Value;
     } 
     
     public async Task<string?> Login(AuthRequest request, IUserRepository userRepository) 
     {
         var user = await _userManager.FindByEmailAsync(request.Email);
         if (user is null){
             throw new NotFoundException(nameof(user), request.Email); 
         }
    
         var isCorrect = await _signInManager.PasswordSignInAsync(userName: user.UserName, request.Password,isPersistent:true, lockoutOnFailure:false);
         if (!isCorrect.Succeeded){
             throw new BadRequestException($"invalid credentials for user: {request.Email}"); 
         }
         
         var customeUser = await userRepository.GetUserByEmail(user.Email);
         JwtSecurityToken token = await GenerateToken(user, customeUser.Id.ToString());
         var Token = new JwtSecurityTokenHandler().WriteToken(token);
         return Token; 
     
     } 
     
     public async Task<bool?> Register(CreateUserDto req, IUserRepository userRepository) 
     {
         var alreadyExist = await _userManager.FindByEmailAsync(req.Email); 
         if (alreadyExist is not null){
             throw new BadRequestException("Email already used");
         }
         var user = new ApplicationUser { 
             Email = req.Email, 
             UserName = req.Username, 
             EmailConfirmed = true
         };
         var creatingUser = await _userManager.CreateAsync(user, req.Password);
         if (!creatingUser.Succeeded){
             throw new BadRequestException($"Check Your Password \n"); 
         }

         var newUser = await userRepository.GetUserByEmail(req.Email);
         if (newUser.Id == 1)
         {
             await userRepository.ChangeUserRole(newUser, Roles.Admin);
         }
         
         return true;
     }
     private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user, string Id){
         var claims = new[]{
             new Claim(JwtRegisteredClaimNames.Sub, user.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Email, user.Email),
             new Claim("reader", Id)
    
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

     public async Task<bool> Update(UpdateUserDto request, string prevEmail){
         
         var user = await _userManager.FindByEmailAsync(prevEmail);
         user.Email = request.Email;
         user.UserName = request.Username; 
         var result = await _userManager.UpdateAsync(user);
         return result.Succeeded;
     }
     
}