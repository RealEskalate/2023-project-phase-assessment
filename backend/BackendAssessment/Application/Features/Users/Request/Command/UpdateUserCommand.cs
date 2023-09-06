using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Request.Command
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserDTO? UpdateUserDTO { get; set; }
    }
}