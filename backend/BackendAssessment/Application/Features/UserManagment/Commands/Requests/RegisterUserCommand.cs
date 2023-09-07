using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.DTOs.Authentication;
using MediatR;

namespace BackendAssessment.Application.Features.UserManagment.Commands.Requests;

public class RegisterUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}