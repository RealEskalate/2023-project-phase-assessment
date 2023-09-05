using ErrorOr;
using MediatR;
using Backend.Domain.Entities;
using Backend.Application.Common.Interface.Authentication;
using Backend.Application.Persistence.Contracts;
using Backend.Application.Features.Auth.Requests.Queries;
using Backend.Domain.Errors;
using AutoMapper;
using Backend.Application.Services.Authentication;
using Backend.Application.DTOs.Users;

namespace Backend.Application.Handlers.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IMapper _mapper;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHashService passwordHashService, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (query.UserName is null && query.Email is null)
            return Errors.Auth.UsernameEmailrequired;

        var identifier = (query.UserName ?? query.Email) ?? throw new Exception("Username or Email is required");

        User user = _userRepository.GetUserByIdentifier(identifier);
        if (user is null)
            return Errors.Auth.WrongCreadital;
        
        if (!user.Verified)
            return Errors.Auth.EmailNotConfirmed;

        if (!_passwordHashService.VerifyPassword(query.Password, user.Password))
            return Errors.Auth.WrongCreadital;

        var token = _jwtTokenGenerator.GenerateToken(user);

        UserDto userDto = _mapper.Map<UserDto>(user);

        return new AuthenticationResult(
            userDto,
            token
        );
    }
}