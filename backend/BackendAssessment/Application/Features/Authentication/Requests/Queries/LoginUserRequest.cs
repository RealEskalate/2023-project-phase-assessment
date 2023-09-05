using Application.Common.Responses;
using Application.Features.Authentication.Dtos;
using MediatR;

namespace Application.Features.Authentication.Requests.Queries;

public class LoginUserRequest : IRequest<CommonResponse<LoggedInUserDto>>
{
    public LoginUserDto LoginUserDto { get; set; } = null!;
}
