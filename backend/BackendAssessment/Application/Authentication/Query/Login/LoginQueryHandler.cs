using MediatR;
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
using SocialMediaApp.Application.Authentication.Query.Login;

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public class LoginQueryHandler : IRequestHandler<LoginQuary, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuary query, CancellationToken cancellationToken)
        {
            //validate if the user exists

            if ( _userRepository.GetByEmail(query.Email) is not User user)
            {
                throw new Exception("User with the given email does not exist");
            }
            // validate if the password is correct

            if (user.Password != query.Password)
            {
                throw new Exception("Password is incorrect");
            }

            // generate token

            var token = _jwtTokenGenerator.GenerateJwtToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
