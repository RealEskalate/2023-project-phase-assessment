namespace Application.Dtos.Auth;

public class LoginUserDto
{

    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}