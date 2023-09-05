using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Backend.Application.Services.Authentication;
using MediatR;

namespace Backend.Application.Features.Auth.Requests.Commands
{
    public class VerifyEmailCommand : IRequest<ErrorOr<AuthenticationResult>>
    {
        public string Token { get; set; }
    }
}