using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.DTOs.Authentication;
using MediatR;


namespace BackendAssessment.Application.Features.Authentication.Requests.Queries;

public class LoginUserRequest : IRequest<CommonResponse<LoggedInUserDto>>
{
    public LoginUserDto LoginUserDto { get; set; } = null!;
}
