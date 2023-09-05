using Application.Dtos.Auth;
using Application.Features.Auth.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<string> Login(LoginUserDto loginUserDto)
    {
        return await _mediator.Send(new LoginUserRequest(){LoginUserDto = loginUserDto});
    }

    [HttpPost("register")]
    public async Task<string> Register(RegisterUserDto registerUserDto)
    {
        return await _mediator.Send(new RegisterUserCommand(){RegisterUserDto = registerUserDto});
    }
}
