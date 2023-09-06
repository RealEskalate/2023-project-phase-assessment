using AutoMapper;
using ErrorOr;
using Application.Common.Interface.Authentication;
using Application.Common.Interface.Services;
using Application.Contracts;
using Domain.Entities;
using Domain.Errors;
using MediatR;

namespace Application.Features.Auth.Handlers.CommandHandlers
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, ErrorOr<string>>
    {
        private readonly IEmailSender _emailSender;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public ForgotPasswordRequestHandler(IEmailSender emailSender, IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _emailSender = emailSender;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        
        public async Task<ErrorOr<string>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user is null)
            {
                return Errors.User.UserNotFound;
            }

            var resetToken = _jwtTokenGenerator.GenerateRecoveryToken(user.Email);

            await _emailSender.SendEmail(
                new Email()
                {
                    To = user.Email,
                    Subject = "Reset Password",
                    Body = $"Please copy this token to reset your password: {resetToken}"
                }
            );

            ErrorOr<string> res = "Please check your email to reset your password";
            return res;
        }
    }
}
