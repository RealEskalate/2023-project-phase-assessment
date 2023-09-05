using Application.Dtos.Common;

namespace Application.Dtos;

public class UserDto : BaseDto{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}