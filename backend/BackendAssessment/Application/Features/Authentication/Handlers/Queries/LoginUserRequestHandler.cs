using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Infrastructure;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.Authentication;
using ProductHub.Application.DTOs.Authentication.Validators;
using ProductHub.Application.Features.Authentication.Requests.Queries;

namespace ProductHub.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHandler
    : IRequestHandler<LoginUserRequest, CommonResponse<LoggedInUserDto>>
{
    private IUnitOfWork _unitOfWork;
    private IJwtGenerator _jwtGenerator;
    private IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserRequestHandler(
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
        LoginUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new LoginUserDtoValidator();
        var validationResult = dtoValidator.Validate(request.LoginUserDto);

        if (validationResult.IsValid == false)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
        }

        // Check user existence and password
        var existingUser = await _unitOfWork.UserRepository.GetByUsername(request.LoginUserDto.UserName);
        if (existingUser == null)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "User not found." }
            };
        }

        var passwordsMatch = _passwordHasher.VerifyPassword(
            existingUser.Password,
            request.LoginUserDto.Password
        );

        if (passwordsMatch == false)
        {
            return new CommonResponse<LoggedInUserDto>
            {
                IsSuccess = false,
                Message = "User login failed.",
                Error = new List<string> { "Username or Password is incorrect." }
            };
        }
        var User = _mapper.Map<UserDto>(existingUser);
        var token = _jwtGenerator.Generate(existingUser);

        return new CommonResponse<LoggedInUserDto>
        {
            IsSuccess = true,
            Message = "User login successfull.",
            Value = new LoggedInUserDto { UserDto = User, Token = token }
        };
    }
}
