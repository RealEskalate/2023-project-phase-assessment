
namespace Application.DTOs.User
{
    public class CreateUserDto : IUserDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
