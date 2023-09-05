using Application.DTOs.Common;

namespace Application.DTOs.User;

public class UserDto : GenericDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
}