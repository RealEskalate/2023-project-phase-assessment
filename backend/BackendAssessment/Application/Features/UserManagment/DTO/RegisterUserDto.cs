namespace BackendAssessment.Application.DTOs.Authentication;

public class RegisterUserDto : IUserDto
{


    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
  
}
