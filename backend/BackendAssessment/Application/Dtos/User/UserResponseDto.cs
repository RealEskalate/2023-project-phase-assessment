
using Application.Dtos.Common;

namespace Application.Dtos.User;

public class UserResponseDto : BaseDto
{
    public string UserName { get; set;} = string.Empty;
    public string Email { get; set; } = string.Empty;

}