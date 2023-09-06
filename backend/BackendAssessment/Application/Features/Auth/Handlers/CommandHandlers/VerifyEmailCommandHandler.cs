using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Application.Common.Interface.Authentication;
using Application.DTOs.Users;
using Application.Features.Auth.Requests.Commands;
using Application.Contracts;
using Application.Services.Authentication;
using Domain.Entities;
using Domain.Errors;
using MediatR;
using Galacticos.Application.Features.Auth.Requests.Commands;
using Domain.Entites;

namespace Application.Features.Auth.Handlers.CommandHandlers
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

            int UserId = _jwtTokenValidation.ExtractUserIdFromToken(request.Token);
            
            if(UserId == 0)
            {
                return Errors.Auth.InvalidToken;
            }

            User user = await _userRepository.GetUserById(UserId);
            if(user == null)
            {
                return Errors.Auth.InvalidToken;
            }

            if(user.Verified)
            {
                return Errors.Auth.EmailAlreadyConfirmed;
            }

            user.Verified = true;
            User usr =await _userRepository.UpdateUser(user);
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