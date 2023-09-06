using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string UserName { get; set; } = string.Empty;
       
        [Required]
        [MinLength(6)]
        [Compare("PasswordComfirmation", ErrorMessage = "Password Does not Match.")]
        public string Password { get; set; } = string.Empty;
        
        public string PasswordComfirmation { get; set; } = string.Empty;
    }
}
