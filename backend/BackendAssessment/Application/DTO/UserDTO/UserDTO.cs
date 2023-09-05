using Application.DTO.UserDTO;

namespace Application.DTO.UserDTO;

public class UserDTO : IUserDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
}
