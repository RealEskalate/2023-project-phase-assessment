using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required] 
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string UserName { get; set; } = string.Empty;
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [MinLength(6)]
        [Compare("PasswordComfirmation", ErrorMessage = "Password Does not Match.")]
        public string Password { get; set; } = string.Empty;
        
        public string PasswordComfirmation { get; set; } = string.Empty;
    }
}