using Application.Model;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class LoginRequest: IRequest<BaseCommandResponse<AuthResponse?>>{
    public required AuthRequest LoginDto { get; set; }
}