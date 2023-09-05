﻿using System.Security.Claims;
using MediatR;

namespace WebApi.Service;

public class AuthHelper
{
    public static Task<int> CheckUserById(ClaimsPrincipal user, int id)
    {
        var userRoleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        if (userRoleClaim == null)
        {
            throw new Exception("User not authenticated");
        }
        
        if (userRoleClaim.Value == "Admin")
        {
            return Task.FromResult(id);
        }
        
        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        var userId = int.Parse(userIdClaim!.Value);
            
        if (userId != id)
        {
            throw new Exception("User not authorized");
        }

        return Task.FromResult(userId);
    }
    
    public static Task<Unit> OnlyAdminUser(ClaimsPrincipal user)
    {
        var userRoleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        if (userRoleClaim == null)
        {
            throw new Exception("User not authenticated");
        }
        
        if (userRoleClaim.Value != "Admin")
        {
            throw new Exception("User not authenticated");
        }
        
        return Unit.Task;
    }
    
    public static Task<string> CheckUserByEmail(ClaimsPrincipal user, string email)
    {
        var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
        if (emailClaim == null)
        {
            throw new Exception("User not authenticated");
        }
            
        var userEmail = emailClaim.Value;
        
        if (userEmail != email)
        {
            throw new Exception("User not authorized");
        }
        
        return Task.FromResult(email);
    }
    
    public static Task<int> GetUserId(ClaimsPrincipal user)
    {
        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new Exception("User not authenticated");
        }
            
        var userId = int.Parse(userIdClaim.Value);
        return Task.FromResult(userId);
    }
}