
using Application.DTOs.User;
using Application.Model;
using Application.Responses;
using Domain;
using MediatR;

namespace Application.Features.User.Request.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse<AuthResponse?>>
        {
            public required CreateUserDto CreateUser { get; set; }

        }
    
}
