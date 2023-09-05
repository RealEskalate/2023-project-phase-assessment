
using Application.Contracts;
using Application.Contracts.Identity;
using Application.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

using Persistence.Model;

namespace Persistence.Service;

public class AuthRepository : IAuthRepository
{

    private readonly UserManager<ApplicaionUser> _userManager;
    private readonly SignInManager<ApplicaionUser> _signInManager;

    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    private readonly RoleManager<IdentityRole> _roleManager;
   

    public AuthRepository(UserManager<ApplicaionUser> userManager, SignInManager<ApplicaionUser> signInManager, IJwtGenerator jwtGenerator,IUserRepository userRepository, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
        _roleManager = roleManager;
        
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new NotFoundException(nameof(ApplicaionUser), email);

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

        if (result.Succeeded)
        {  
            var userToReturn = await _userRepository.GetByEmailAsync(email);
            

            return await _jwtGenerator.CreateToken(userToReturn!);
        }

        return "Failed";
    }

    public async Task<string> RegisterAsync(string email, string password, string username)
    {
        var DoesExist = _userManager.FindByEmailAsync(email);

        if (DoesExist is not null){
             throw new BadRequestException("Email already exists");
         }

         var user = new ApplicaionUser { 
             Email = email,
             UserName = username, 
             EmailConfirmed = true
         };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded){
             throw new BadRequestException($"Failed to create user {result.Errors}"); 
         } 
         
         

         var userToReturn = await _userRepository.GetByEmailAsync(email);

        if(userToReturn!.Id > 2){
            if (!_roleManager.RoleExistsAsync("user").Result)
            {
                var role = new ApplicationRole { Name = "user" };
                await _roleManager.CreateAsync(role);
            }
        }else {
            if (!_roleManager.RoleExistsAsync("admin").Result){

                var role = new ApplicationRole{Name = "admin"};
                await _roleManager.CreateAsync(role);
            }
        }
        

            await _userManager.AddToRoleAsync(user, "user");

         return await _jwtGenerator.CreateToken(userToReturn!);
    }
}