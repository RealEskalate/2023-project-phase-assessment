using Application.DTO.Common;

namespace Application.DTO.User
{
    public class CreateUserDTO : BaseDTO
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}