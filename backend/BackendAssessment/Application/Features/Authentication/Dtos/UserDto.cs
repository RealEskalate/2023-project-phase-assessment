using Application.Common.Dtos;

namespace Application.Features.Authentication.Dtos;

public class UserDto : BaseDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
}
