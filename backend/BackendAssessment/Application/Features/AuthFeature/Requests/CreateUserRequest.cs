using Application.Model;
using Application.Responses;
using MediatR;

namespace Application.Features.AuthFeature.Requests;

public class CreateUserRequest : IRequest<BaseCommandResponse<AuthResponse>>{
    
    public required RegisterRequest Register { get; set; }
}