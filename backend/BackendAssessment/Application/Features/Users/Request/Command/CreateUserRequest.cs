using Application.DTO.Users;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request.Command
{
    public class CreateUserRequest : IRequest<User>
    {
        public UserDto? User { get; set; }
    }
}
