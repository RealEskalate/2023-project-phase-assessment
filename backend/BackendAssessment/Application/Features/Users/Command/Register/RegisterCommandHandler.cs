using MediatR;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SocialMediaApp.Application.Authentication.Common;
using Application.Exceptions;
using Application.Persistence.Contracts;
using Microsoft.AspNetCore.Http;
using Application.Persistence.Contracts.Common;
using Application.Contracts.persistence;
using Application.Authentication.Command.Validations;

namespace Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        private readonly IPasswordService _passwordService;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordService passwordService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<String> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            
            // validate if the user email does not exist

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            string h_password = _passwordService.HashPassword(command.Password);
            // create a new user (generate unique Id ) and add it to the database

            var user = new User
            {
                Username = command.Name,
                Email = command.Email,
                Password = h_password,

            };
            var validator = new ValidateCreateUserDto();
            var validationResult = await validator.ValidateAsync(user);

            if (validationResult.IsValid == true)
            {
                _userRepository.AddUser(user);


                var token = _jwtTokenGenerator.GenerateToken(user);

                return token;
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
