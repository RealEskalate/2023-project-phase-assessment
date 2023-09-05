using Domain.Entities;

namespace Application.Features.Authentication.Dtos;

public class RegisterUserDto : IUserDto
{
    public UserRole Role { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
