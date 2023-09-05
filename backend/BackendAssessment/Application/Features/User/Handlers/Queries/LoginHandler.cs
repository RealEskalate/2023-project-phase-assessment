using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Features.User.Request.Queries;
using Application.Model;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class LoginHandler : IRequestHandler<LoginRequest, BaseCommandResponse<AuthResponse>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;


    public LoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<BaseCommandResponse<AuthResponse>> Handle(LoginRequest request, CancellationToken cancellationToken){
        try{
            var token = await _authService.Login(new AuthRequest(){
                Email = request.LoginDto.Email,
                Password = request.LoginDto.Password
            }, _unitOfWork.UserRepository);
            var user = await _unitOfWork.UserRepository.GetUserByEmail(request.LoginDto.Email);
            var res = new AuthResponse(){ Id = user.Id, Email = user.Email, Username = user.Username, Token = token };
            return BaseCommandResponse<AuthResponse>.SuccessHandler(res);

        }
        catch(Exception ex){
            return BaseCommandResponse<AuthResponse>.FailureHandler(ex);
        }
    }
}