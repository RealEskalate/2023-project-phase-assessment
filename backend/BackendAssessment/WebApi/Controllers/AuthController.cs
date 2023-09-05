using Application.DTOs.Auth;
using Application.DTOs.User;
using Application.Features.Auth.LogIn;
using Application.Features.User.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserResponseDto>> Register(UserRequestDto userDto)
    {
        if (userDto == null)
        {
            throw new Exception("");
        }
        var response = await _mediator.Send(new CreateUserCommand
        {
            UserDto = userDto
        });
        return response;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(AuthRequest authRequest)
    {
        var response = await _mediator.Send(new LoginUserCommand
        {
            AuthRequest = authRequest
        });
        return response;
    }
}