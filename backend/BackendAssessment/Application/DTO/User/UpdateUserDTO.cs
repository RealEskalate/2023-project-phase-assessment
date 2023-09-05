using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User
{
    public class UpdateUserDTO 
    {

        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}