using MediatR;

namespace Application.Features.User.Commands.Delete;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
}