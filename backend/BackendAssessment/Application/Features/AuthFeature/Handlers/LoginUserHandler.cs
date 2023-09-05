using Application.Contracts.Identity;
using Application.Features.AuthFeature.Requests;
using Application.Model;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.AuthFeature.Handlers;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, BaseCommandResponse<AuthResponse>>{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    
    public LoginUserHandler(IAuthService authService, IMapper mapper){
        _authService = authService;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<AuthResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken){
        try{
            
            var reponse = await _authService.Login(request.Login);
            return BaseCommandResponse<AuthResponse>.SuccessHandler(reponse);

        }
        catch(Exception e){
            return BaseCommandResponse<AuthResponse>.FailureHandler(e);

        }
    }
    
}