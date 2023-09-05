using Application.DTOs.Common;

namespace Application.DTOs.User;

public class UserResponseDto : BaseDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsAdmin { get; set; }
}