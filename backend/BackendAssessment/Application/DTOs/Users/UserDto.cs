using Backend.Application.DTOs.Common;

namespace Backend.Application.DTOs.Users
{
    public class UserDto : BaseEntityDto{
        public string FirstName { set; get; } = null!;
        public string LastName { set; get; } = null!;
        public string UserName { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string Bio { set; get; } = "";
        public string Picture { set; get; } = "";
        public string Role { set; get; } = null!;
    }
}