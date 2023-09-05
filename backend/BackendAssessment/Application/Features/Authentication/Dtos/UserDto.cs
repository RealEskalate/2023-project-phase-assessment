using Application.Common.Dtos;

namespace Application.Features.Authentication.Dtos;

public class UserDto : BaseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
