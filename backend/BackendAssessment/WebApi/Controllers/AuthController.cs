using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto model)
    {
        // Call the registration service
        string token = await _authenticationService.RegisterAsync(model);

        if (!string.IsNullOrEmpty(token))
        {
            return Ok(new { Token = token });
        }
        else
        {
            return BadRequest("Registration failed.");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto model)
    {
        // Call the login service
        string token = await _authenticationService.LoginAsync(model);

        if (!string.IsNullOrEmpty(token))
        {
            return Ok(new { Token = token });
        }
        else
        {
            return Unauthorized("Login failed.");
        }
    }
}
