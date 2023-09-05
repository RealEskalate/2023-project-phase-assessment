using Application.DTOs.User;
using MediatR;

namespace Application.Features.Users.Request.Command
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserDto? UpdateUserDTO { get; set; }
        public Guid id { get; set; }
    }
}