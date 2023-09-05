using Application.Model;
using Application.Response;
using MediatR;

namespace Application.Features.User.Requests.Queries;

public class LoginRequest: IRequest<BaseCommandResponse<AuthResponse?>>{
    public required AuthRequest LoginDto { get; set; }
}