using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.DTOs.User
{
    public class UpdateUserDto : BaseDto, IUserDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
    }
}
