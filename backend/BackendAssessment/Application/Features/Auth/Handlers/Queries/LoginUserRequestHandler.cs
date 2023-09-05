using Application.Contracts;
using Application.Contracts.Identity;
using Application.Dtos.Auth.Valiation;
using Application.Exceptions;
using Application.Features.Auth.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Handlers.Commands;

public class LoginUserRequestHanlder : IRequestHandler<LoginUserRequest, string>
{
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public LoginUserRequestHanlder(IAuthRepository authRepository, IJwtGenerator jwtGenerator, IMapper mapper,  IUserRepository userRepository)
    {
        
        _authRepository = authRepository;
        _mapper = mapper;
        _userRepository = userRepository;

    }

    public async Task<string> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new LoginUserDtoValidator();
        var validationResult =   validator.Validate(request.LoginUserDto);
        if (!validationResult.IsValid){
            throw new ValidationErrorException(validationResult);
        }
        var user =  _mapper.Map<Domain.Entities.User>(request.LoginUserDto);
        var result = _userRepository.AddAsync(user).Result ?? throw new BadRequestException("User already exists");

        var token =  _authRepository.LoginAsync(user.Email,user.PasswordHash).Result;
        
        return Task.FromResult(token).Result;
    }
}