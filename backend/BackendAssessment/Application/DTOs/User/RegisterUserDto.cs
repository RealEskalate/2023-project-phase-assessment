using Domain.Entities;

namespace Application.Features.Authentication.Dtos;

public class RegisterUserDto : IUserDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }
}
