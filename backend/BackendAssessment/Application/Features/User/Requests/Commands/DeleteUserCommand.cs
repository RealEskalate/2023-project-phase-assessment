using MediatR;

namespace Application.Features.User.Requests.Commands;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
}