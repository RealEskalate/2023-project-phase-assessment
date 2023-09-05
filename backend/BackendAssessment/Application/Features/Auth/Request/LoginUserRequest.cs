using BackendAssessment.Application.DTOs.Auth;
using BackendAssessment.Application.DTOs.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Request
{
    public class LoginUserRequest : IRequest<LoginResponseDto>
    {
        public LoginRequestDto loginRequest { get; set; }
    }
}
