using Application.Contracts;
using Application.Contracts.Identity;
using Application.Dtos.Auth.Valiation;
using Application.Exceptions;
using Application.Features.Auth.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Handlers.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IAuthRepository authRepository, IJwtGenerator jwtGenerator, IMapper mapper,  IUserRepository userRepository)
    {
        
        _authRepository = authRepository;
        _mapper = mapper;
        _userRepository = userRepository;

    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterUserDtoValidator(_userRepository);
        var validationResult = validator.Validate(request.RegisterUserDto);
        if (!validationResult.IsValid){
            throw new ValidationErrorException(validationResult);
        }
        var user = _mapper.Map<Domain.Entities.User>(request.RegisterUserDto);
        var result = _userRepository.AddAsync(user).Result ?? throw new BadRequestException("User already exists");

        var token = await _authRepository.RegisterAsync(user.Email,user.PasswordHash,user.Username);
        return token;
    }
}

