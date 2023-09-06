using Application.DTO.Common;

namespace Application.DTO.User
{
    public class UpdateUserDTO : BaseDTO
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsAdmin { get; set; }
    }
}