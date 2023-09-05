using Application.Dtos.Common;

namespace Application.Contracts;

public class UpdateUserDto : BaseDto
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}