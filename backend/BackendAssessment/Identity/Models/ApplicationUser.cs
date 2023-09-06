using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public DateTime? DateCreated { get; set; }
        public string? PasswordComfirmation { get; set; }
        public string? ConnectionId { get; set; }
    }
}
