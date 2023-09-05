using System.ComponentModel.DataAnnotations;


namespace Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}