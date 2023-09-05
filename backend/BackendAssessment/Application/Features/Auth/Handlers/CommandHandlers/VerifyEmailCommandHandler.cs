using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Backend.Application.Common.Interface.Authentication;
using Backend.Application.DTOs.Users;
using Backend.Application.Features.Auth.Requests.Commands;
using Backend.Application.Persistence.Contracts;
using Backend.Application.Services.Authentication;
using Backend.Domain.Entities;
using Backend.Domain.Errors;
using MediatR;

namespace Backend.Application.Features.Auth.Handlers.CommandHandlers
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenValidation _jwtTokenValidation;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public VerifyEmailCommandHandler(IUserRepository userRepository, IJwtTokenValidation jwtTokenValidation, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenValidation = jwtTokenValidation;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            // bool isTokenValid = _jwtTokenValidation.ValidateToken(request.Token);
            // Console.WriteLine("This token id: "+ request.Token );
            // if (!isTokenValid)
            // {
            //     return Errors.Auth.InvalidToken;
            // }

            Guid UserId = _jwtTokenValidation.ExtractUserIdFromToken(request.Token);
            
            if(UserId == Guid.Empty)
            {
                return Errors.Auth.InvalidToken;
            }

            User user = _userRepository.GetUserById(UserId);
            if(user == null)
            {
                return Errors.Auth.InvalidToken;
            }

            if(user.Verified)
            {
                return Errors.Auth.EmailAlreadyConfirmed;
            }

            user.Verified = true;
            User usr =_userRepository.EditUser(user);
            if(usr == null)
            {
                return Errors.Auth.EmailNotConfirmed;
            }


            var Token = _jwtTokenGenerator.GenerateToken(usr);
            var res = new AuthenticationResult(_mapper.Map<UserDto>(user), Token); 
            
            return res;
        }

    }
}