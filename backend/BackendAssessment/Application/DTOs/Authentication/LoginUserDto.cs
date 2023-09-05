using ProductHub.Application.DTOs.Authentication;

namespace ProductHub.Application.DTOs.Authentication;

public class LoginUserDto : IUserDto
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
