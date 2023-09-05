using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Identity.DTO
{
    public class AuthRequestDTO : IGenericIdentityDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
