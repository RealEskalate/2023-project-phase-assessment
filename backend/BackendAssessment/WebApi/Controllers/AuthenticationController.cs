using Application.Authentication.Command.Register;
using Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Authentication.Query.Login;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Name, request.Email, request.Password);

            string authResult = await _mediator.Send(command);

            if (authResult == null)
            {
                throw new Exception();
            }
            return Ok(authResult);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuary(request.Email, request.Password);
            var authResult = await _mediator.Send(query);
            var authResponse = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.Email,
                authResult.User.Username,
                authResult.Token);
            return Ok(authResponse);
        }
    }
}
