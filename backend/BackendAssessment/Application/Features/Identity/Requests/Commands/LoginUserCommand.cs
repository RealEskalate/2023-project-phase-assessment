using Application.Common;
using Application.DTO.Identity.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Requests.Commands
{
    public class LoginUserCommand : IRequest<BaseResponse<AuthResponseDTO>>
    {
        public AuthRequestDTO RequestData { get; set; }
    }
}
