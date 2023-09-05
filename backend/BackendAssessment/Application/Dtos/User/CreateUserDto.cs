using Application.Dtos.Common;

namespace Application.Dtos;
public class CreateUserDto : BaseDto{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
