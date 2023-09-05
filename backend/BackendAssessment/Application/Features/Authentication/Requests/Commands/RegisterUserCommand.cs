using Application.Common.Responses;
using Application.Features.Authentication.Dtos;
using MediatR;

namespace Application.Features.Authentication.Requests.Commands;

public class RegisterUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
