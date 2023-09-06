using AutoMapper;
using ErrorOr;
using Application.Common.Interface.Authentication;
using Application.Contracts;
using Application.Services.Authentication;
using Domain.Errors;
using MediatR;
using Application.Features.Users.Request.Command;

namespace Application.Features.Users.Handler.Command
{
    public class UpdatePasswordTokenRequestHandler : IRequestHandler<UpdatePasswordTokenRequest, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtTokenValidation _jwtTokenValidation;
        private readonly IMapper _mapper;

        public UpdatePasswordTokenRequestHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService, IJwtTokenValidation jwtTokenValidation)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
            _jwtTokenValidation = jwtTokenValidation;
        }

        public async Task<ErrorOr<string>> Handle(UpdatePasswordTokenRequest request, CancellationToken cancellationToken)
        {
            var email = _jwtTokenValidation.ExtractEmailFromToken(request.Token);

            if (email == null)
            {
                return Errors.User.InvalidEmail;
            }
            
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            if (request.updatePasswordTokenRequestDTO.NewPassword != request.updatePasswordTokenRequestDTO.ConfirmNewPassword)
            {
                return Errors.User.PasswordNotMatch;
            }

            var userToEdit = _mapper.Map(request, user);
            userToEdit.Password = _passwordHashService.HashPassword(request.updatePasswordTokenRequestDTO.NewPassword);
            await _userRepository.UpdateUser(userToEdit);
            return $"Password updated successfully";
        }
    }
}