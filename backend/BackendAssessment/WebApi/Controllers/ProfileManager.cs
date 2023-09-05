using System.Security.Claims;
using Application.Common;
using Application.Contracts.Identity;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
public class ProfileManager : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _contextAccessor;

    public ProfileManager(IUserService userService, IHttpContextAccessor contextAccessor)
    {
        _userService = userService;
        _contextAccessor = contextAccessor;
    }

    // get user by id
    [HttpGet("api/[controller]/[action]")]
    public async Task<ActionResult<User>> GetUserInfo()
    {
        // get the user from the http context
        var id = _contextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid);
        
        return Ok(await _userService.GetUserById(id!));
    }
    
    // update user
    [HttpPut("api/[controller]/[action]")]
    public async Task<ActionResult> UpdateUser(UpdateUserDto user)
    {
        CheckUserId(user.Id.ToString());
        
        await _userService.UpdateUser(user);
        return NoContent();
    }
    
    // delete user
    [HttpDelete("api/[controller]/[action]")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        CheckUserId(id);

        await _userService.DeleteUser(id);
        return NoContent();
    }
    
    
    
    // check user id 
    private void CheckUserId(string userId)
    {
        var loggedUserId = _contextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid);

        if (loggedUserId != userId)
            throw new UnauthorizedAccessException("You are not authorized to perform this action.");
    }

}