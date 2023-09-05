
using Application.Dtos.User;
using MediatR;

namespace Application.Features.User.Commands.Create;

public class CreateUserCommand : IRequest<UserResponseDto>
{
    public UserRequestDto NewUser { get; set; } = null!;
}