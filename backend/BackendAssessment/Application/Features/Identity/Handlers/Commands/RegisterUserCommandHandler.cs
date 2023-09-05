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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, BaseResponse<RegistrationResponseDTO>>
    {
        private readonly IAuthService _authService;

        public RegisterUserHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<BaseResponse<RegistrationResponseDTO>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //var validator = new RegistrationRequestValidation(_authService);
            //var validationResult = await validator.ValidateAsync(request.RequestData);

            //if (!validationResult.IsValid)
            //{
            //    throw new ValidationException(validationResult);
            //}

            var registedUser = await _authService.Register(request.RequestData);

            return new BaseResponse<RegistrationResponseDTO>()
            {
                Success = true,
                Message = "User Registered Successfully",
                Value = registedUser
            };
        }
    }
}
