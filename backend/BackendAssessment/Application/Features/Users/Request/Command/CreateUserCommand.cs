using Application.DTOs.User;
using MediatR;

namespace Application.Features.Users.Request.Command
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public CreateUserDto? CreateUserDTO { get; set; }
    }
}