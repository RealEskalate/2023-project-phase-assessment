using Application.DTO.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request.Command
{
    public class UpdateUserRequest: IRequest<UserDto>
    {
        public UserDto user { get; set; }
    }
}
