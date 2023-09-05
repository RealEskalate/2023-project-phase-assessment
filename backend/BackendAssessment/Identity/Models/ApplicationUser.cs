using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateCreated { get; set; }
        public string? PasswordConfirmation { get; set; }
    }
}
