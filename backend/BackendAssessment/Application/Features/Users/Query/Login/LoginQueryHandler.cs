using MediatR;
using Application.Persistence.Contracts.Common;
using Application.Persistence.Contracts;
using Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SocialMediaApp.Application.Authentication.Common;
using Application.Authentication.Query.Login;
using Application.Contracts.persistence;

namespace Application.Authentication.Command.Register
{
    public class LoginQueryHandler : IRequestHandler<LoginQuary, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        private readonly IPasswordService _passwordService;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordService passwordService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<AuthenticationResult> Handle(LoginQuary query, CancellationToken cancellationToken)
        {
            //validate if the user exists
            if (_userRepository.GetByEmail(query.Email) is not User user)
            {
                throw new Exception("User with the given email does not exist");
            }
            // validate if the password is correct

            if (!_passwordService.VerifyPassword(query.Password, user.Password))
            {
                throw new Exception("Password is incorrect");
            }
            

            // generate token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
