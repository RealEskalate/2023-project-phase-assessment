using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductHub.Application.DTOs.Authentication;
using ProductHub.Application.Features.Authentication.Requests.Commands;
using ProductHub.Application.Features.Authentication.Requests.Queries;

namespace ProductHub.WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries
    [HttpPost("register")]
    public async Task<ActionResult<LoggedInUserDto>> Register([FromBody] RegisterUserDto request)
    {
        var response = await _mediator.Send(new RegisterUserCommand { RegisterUserDto = request });
        return Ok(response);
    }

    #endregion
    #region Commands
    [HttpPost("login")]
    public async Task<ActionResult<LoggedInUserDto>> Login([FromBody] LoginUserDto request)
    {
        var response = await _mediator.Send(new LoginUserRequest { LoginUserDto = request });
        return Ok(response);
    }
    #endregion
}
