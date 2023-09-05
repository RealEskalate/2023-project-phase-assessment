using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackendAssessment.Application.DTOs.Authentication;
using BackendAssessment.Application.Features.UserManagment.Commands.Requests;
using SocialSync.Application.Features.Authentication.Requests.Queries;


namespace BackendAssessment.WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

   
    [HttpPost("register")]
    public async Task<ActionResult<LoggedInUserDto>> Register([FromBody] RegisterUserDto request)
    {
        var response = await _mediator.Send(new RegisterUserCommand { RegisterUserDto = request });
        return Ok(response);
    }

  
  
    [HttpPost("login")]
    public async Task<ActionResult<LoggedInUserDto>> Login([FromBody] LoginUserDto request)
    {
        var response = await _mediator.Send(new LoginUserRequest { LoginUserDto = request });
        return Ok(response);
    }
    
}
