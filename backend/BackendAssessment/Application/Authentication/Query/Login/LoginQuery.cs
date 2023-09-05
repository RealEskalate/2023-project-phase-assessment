using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Authentication.Common;

namespace SocialMediaApp.Application.Authentication.Query.Login
{
    public record LoginQuary(
        string Email,
        string Password) : IRequest<AuthenticationResult>;

}
