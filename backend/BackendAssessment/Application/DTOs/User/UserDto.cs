using Application.DTOs;

namespace Application.DTOs.User;

public class UserDto : BaseDto
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
}