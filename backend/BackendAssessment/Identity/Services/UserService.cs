using System.Security.Claims;
using Application.Common;
using Application.Contracts.Identity;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Models.Identity;
using Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _contextAccessor;
    public UserService(UserManager<ApplicationUser> userManager, IAuthService authService, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _authService = authService;
        _contextAccessor = contextAccessor;
    }

    // get the current user
    public string? UserId => _contextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid);

    public async Task<bool> IsAdmin()
    {
        // get the user by id
        var user = await _userManager.FindByIdAsync(UserId);
        if(user == null)
            throw new NotFoundException("User", UserId);

        return await  _userManager.IsInRoleAsync(user, "Administrator");
    }

    public async Task<User> GetUserById(string userId)
    {
        // get the user using the manager 
        var user = await _userManager.FindByIdAsync(userId);
        
        
        if (user != null)
            return new User()
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
                DateCreated = user.DateCreated,
            };
        throw new NotFoundException("User", userId);
    }

    public async Task UpdateUser(UpdateUserDto user)
    {
        // find the user in the identity database
        var userToUpdate = await _userManager.FindByIdAsync(user.Id.ToString());
        
        if (user == null)
            throw new NotFoundException("User", user!.Id);
        
        // assign the values of user to the userToUpdate
        userToUpdate.Email = user.Email;
        userToUpdate.UserName = user.UserName;
        
        // update the user
        var result = await _userManager.UpdateAsync(userToUpdate);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(er => er.Description).ToArray();
            
            throw new BadRequestException(string.Join(Environment.NewLine, errors));
        }
    }

    public async Task DeleteUser(string id)
    {
        // get the user
        var user =await  _userManager.FindByIdAsync(id);
        
        if (user == null)
            throw new NotFoundException("User", id);
        
        //signout user
        await _authService.SignOut();   
        
        // delete the user
        var result = await  _userManager.DeleteAsync(user);
        
        
        
        
    }
    
    

    public async Task<bool> Exists(string userId)
    {
        try
        {
            await GetUserById(userId);

        }
        catch (NotFoundException)
        {
            return false;
        }

        return true;
    }
}