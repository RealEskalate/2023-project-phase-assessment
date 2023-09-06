using ErrorOr;
using Application.Common.Interface.Authentication;
using Application.Contracts;
using Application.Services.Authentication;
using MediatR;
using Domain.Entities;
using Application.Features.Auth.Requests.Commands;
using AutoMapper;
using Domain.Errors;
using Application.Common.Interface.Services;
using Microsoft.AspNetCore.Http;
using Application.DTOs.Users;
using Domain.Entites;

namespace Application.Handlers.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<string>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IPasswordHashService _passwordHashService;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService, IEmailSender emailSender)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHashService = passwordHashService;
        _emailSender = emailSender;
    }

    public async Task<ErrorOr<string>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // if(_userRepository.GetUserByIdentifier(command.Email) is not null || _userRepository.GetUserByIdentifier(command.UserName) is not null)
        // {
        //     return Task.FromResult<ErrorOr<string>>(Errors.User.DuplicateEmail);
        // }
        if (await _userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        if (await _userRepository.GetUserByUserName(command.UserName) is not null)
        {
            return Errors.User.DuplicateUserName;
        }
        if (command.Password != command.ConfirmPassword)
        {
            return Errors.User.PasswordNotMatch;
        }

        string password = _passwordHashService.HashPassword(command.Password);

        command.Password = password;

        User user = _mapper.Map<User>(command);
        await _userRepository.AddUser(user);

        var verificationToken = _jwtTokenGenerator.GenerateToken(user);
        var http = new HttpContextAccessor();
        var scheme = http.HttpContext?.Request.Scheme ?? "https";
        var host = http.HttpContext?.Request.Host.Value ?? "localhost:44322";
        await _emailSender.SendEmail(new Email()
        {
            To = user.Email,
            Subject = "Social Media App Verification",
            Body = $"Please verify your account by clicking the link below: <br/> <a href='http://localhost:5165/api/auth/verify-email/{verificationToken}'>Verify Email</a>"
        });
        var token = _jwtTokenGenerator.GenerateToken(user);

        UserDto userDto = _mapper.Map<UserDto>(user);

        // return some string that says registration successful but verfiy your email
        ErrorOr<string> res = "Registration successful, please verify your email";
        return res;
    }
}
