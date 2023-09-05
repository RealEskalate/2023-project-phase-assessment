using MediatR;

namespace Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public int UserId { get; set; }
}