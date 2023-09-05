using Application.Contracts;
using MediatR;

namespace Application.Features.User.Requests.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public required UpdateUserDto UpdateUserDto { get; set; }
}