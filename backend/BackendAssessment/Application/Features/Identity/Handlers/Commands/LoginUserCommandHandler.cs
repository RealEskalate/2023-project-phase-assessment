using Application.Common;
using Application.Contracts.Identity;
using Application.DTO.Identity.DTO;
using Application.Features.Identity.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Handlers.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponse<AuthResponseDTO>>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<BaseResponse<AuthResponseDTO>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //var validator = new AuthRequestValidation();
            //var result = await validator.ValidateAsync(request.RequestData);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result);
            //}

            var logedUser = await _authService.Login(request.RequestData);
            return new BaseResponse<AuthResponseDTO>() 
            { 
                Success = true,
                Message = "User Logged In Successfully",
                Value = logedUser
            };
        }
    }

   
}
