﻿using MediatR;
using Application.Persistence.Contracts.Common;
using Application.Persistence.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Authentication.Common;
using Application.Authentication.Command.Validations;
using Application.Exceptions;

namespace Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            
            // validate if the user email does not exist

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            // create a new user (generate unique Id ) and add it to the database

            var user = new User
            {
                UserName = command.Name,
                Email = command.Email,
                Password = command.Password,
               

            };
            var validator = new ValidateCreateUserDto(_userRepository);
            var validationResult = await validator.ValidateAsync(user);

            if (validationResult.IsValid == true)
            {
                _userRepository.AddUser(user);


                var token = _jwtTokenGenerator.GenerateJwtToken(user);

                return new AuthenticationResult(
                    user,
                    token);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
