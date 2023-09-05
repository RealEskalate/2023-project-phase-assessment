using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.User;
using Domain;
using MediatR;

namespace Application.Features.User.Request.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse<AuthResponse?>>
    {
        public required CreateUserDTO CreateUser { get; set; }

    }
    
}