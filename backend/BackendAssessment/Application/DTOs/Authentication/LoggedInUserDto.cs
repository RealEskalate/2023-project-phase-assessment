namespace ProductHub.Application.DTOs.Authentication;

public class LoggedInUserDto
{
    public UserDto UserDto { get; set; } = null!;
    public string Token { get; set; } = null!;
}
