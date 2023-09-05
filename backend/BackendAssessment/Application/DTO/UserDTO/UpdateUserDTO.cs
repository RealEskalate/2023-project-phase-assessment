using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTO.UserDTO
{
    public class UpdateUserDTO : IUserDTO
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public int UserId { get; set; }
    }
}
