
namespace ProductHub.Application.DTOs.Authentication;

public class RegisterUserDto : IUserDto
{
    public string UserName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
}
