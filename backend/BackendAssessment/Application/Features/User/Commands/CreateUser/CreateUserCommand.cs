using Application.DTOs.User;
using MediatR;

namespace Application.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserResponseDto>
{
    public UserRequestDto UserDto { get; set; } = null!;
}