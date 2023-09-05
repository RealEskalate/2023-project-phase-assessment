using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Backend.Application.Features.Auth.Requests.Commands;
using Backend.Application.Features.Auth.Requests.Queries;
using Backend.Application.Handlers.Queries.Login;
using Backend.Application.Services.Authentication;
using Backend.Application.DTOs.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Application.Features.Auth.Handlers.CommandHandlers;

namespace Backend.Api.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthController : ApiController{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {   

        var command = _mapper.Map<RegisterCommand>(request);
        
        ErrorOr<string> authResult = await _mediator.Send(command);
        
        return authResult.Match(
            result => Ok(result),
            error => Problem(error)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query) ;

        
        return authResult.Match<IActionResult>(
            result => Ok(result),
            error => Problem(error)
        );
    }
    
    [HttpGet("verify-email/{token}")]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        var command = new VerifyEmailCommand { Token = token }; // Create a command with the token
        var verificationResult = await _mediator.Send(command);

        return verificationResult.Match<IActionResult>(
            result => Ok(result),    // Redirect to success page or message
            error => Problem(error)   // Redirect to error page or display error message
        );
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
    {
        var forgotPasswordResult = await _mediator.Send(request);

        return forgotPasswordResult.Match<IActionResult>(
            result => Ok(result),    // Redirect to success page or message
            error => Problem(error)   // Redirect to error page or display error message
        );
    }
    
    [HttpPost("set-role")]
    public async Task<IActionResult> SetRole(SetRoleCommand request)
    {
        var command = _mapper.Map<SetRoleCommand>(request);
        
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            result => Ok(result),    // Redirect to success page or message
            error => Problem(error)   // Redirect to error page or display error message
        );
    }

}