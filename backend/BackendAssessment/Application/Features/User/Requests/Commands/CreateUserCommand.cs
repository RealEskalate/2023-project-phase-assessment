using Application.Dtos;
using MediatR;

namespace Application.Features.User.Requests.Commands;

public class CreateUserCommand : IRequest<int>
{
    public required CreateUserDto CreateUserDto { get; set; }
}