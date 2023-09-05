using Application.Contracts.Identity;
using Application.Features.AuthFeature.Requests;
using Application.Model;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.AuthFeature.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, BaseCommandResponse<AuthResponse>>{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    
    public CreateUserHandler(IAuthService authService, IMapper mapper){
        _authService = authService;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<AuthResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken){
        try{
            
            var reponse = await _authService.Register(request.Register);
            return BaseCommandResponse<AuthResponse>.SuccessHandler(reponse);

        }
        catch(Exception e){
            return BaseCommandResponse<AuthResponse>.FailureHandler(e);
        }
    }
    
}