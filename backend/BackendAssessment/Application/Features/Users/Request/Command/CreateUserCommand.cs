using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Request.Command
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public CreateUserDTO? CreateUserDTO { get; set; }
    }
}