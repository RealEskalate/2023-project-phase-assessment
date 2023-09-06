using Application.DTO.Common;

namespace Application.DTO.User
{
    public class GetUserDTO : BaseDTO
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsAdmin { get; set; }
    }
}