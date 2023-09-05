using Application.Dtos.UserDtos;
using Application.Model;
using Application.Response;
using MediatR;

namespace Application.Features.User.Requests.Commands;

public class CreateUserCommand : IRequest<BaseCommandResponse<AuthResponse?>>
{
    public required CreateUserDto CreateUser { get; set; }

}