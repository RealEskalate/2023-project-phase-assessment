using Application.Features.AuthFeature.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Model;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser( RegisterRequest userDto)
        {
            var command = new CreateUserRequest() { Register = userDto };
            var userId = await _mediator.Send(command);
            return ResponseHandler<AuthResponse>.HandleResponse(userId, 201);
        }
        
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginRequest userDto)
        {
            var command = new LoginUserRequest() { Login = userDto };
            var token = await _mediator.Send(command);
            return ResponseHandler<AuthResponse>.HandleResponse(token, 200);
        }
        
       
    }
}