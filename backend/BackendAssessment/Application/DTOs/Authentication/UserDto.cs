using ProductHub.Application.DTOs.Common;

namespace ProductHub.Application.DTOs.Authentication;

public class UserDto : BaseDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
