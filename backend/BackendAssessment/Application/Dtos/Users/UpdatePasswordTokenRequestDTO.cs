
namespace Application.DTOs.Users
{
    public class UpdatePasswordTokenRequestDTO
    {
        public string NewPassword { get; set; } = null!;
        public string ConfirmNewPassword { get; set; } = null!;
    }
}