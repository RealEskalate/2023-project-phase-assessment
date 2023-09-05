using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Users
{
    public class GetUserDto : BaseDto
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
