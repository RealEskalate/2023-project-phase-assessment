using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Infrastructure;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.Authentication;
using ProductHub.Application.DTOs.Authentication.Validators;
using ProductHub.Application.Features.Authentication.Requests.Commands;
using ProductHub.Domain.Entites;

namespace Application.Features.Authentication.Handlers.Commands;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, CommonResponse<LoggedInUserDto>>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(
        IUnitOfWork unitOfWork,
        IJwtGenerator jwtGenerator,
        IMapper mapper,
        IPasswordHasher passwordHasher
    )
    {
        _unitOfWork = unitOfWork;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<CommonResponse<LoggedInUserDto>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new RegisterUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.RegisterUserDto);

        if (validationResult.IsValid == false)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
        }

        var userExists = await _unitOfWork.UserRepository.UsernameExists(
            request.RegisterUserDto.UserName
        );

        if (userExists == true)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = new List<string> { "Username Exists." }
            };
        }

        userExists = await _unitOfWork.UserRepository.EmailExists(request.RegisterUserDto.Email);

        if (userExists == true)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User registration failed.",
                Error = new List<string> { "Email Exists." }
            };
        }
        var createdUser = _mapper.Map<User>(request.RegisterUserDto);
        createdUser.Password = _passwordHasher.HashPassword(createdUser.Password);

        createdUser = await _unitOfWork.UserRepository.AddAsync(createdUser);
        await _unitOfWork.SaveAsync();

        var User = _mapper.Map<UserDto>(createdUser);
        var token = _jwtGenerator.Generate(createdUser);

        return new CommonResponse<LoggedInUserDto>
        {
            IsSuccess = true,
            Message = "User registration success.",
            Value = new LoggedInUserDto { UserDto = User, Token = token }
        };
    }
}

