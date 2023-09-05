using Application.Common;
using Application.DTO.Identity.DTO;
using Application.Features.Identity.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<AuthResponseDTO>>> Login([FromBody] AuthRequestDTO requestData)
        {

            var result = await _mediator.Send(new LoginUserCommand { RequestData = requestData });
            return Ok(result);
        }



        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse<RegistrationResponseDTO>>> Register([FromBody] RegistrationRequestsDTO requestData)
        {
            var result = await _mediator.Send(new RegisterUserCommand { RequestData = requestData });
            return Ok(result);
        }



        //[HttpPost("change-password")]
        //[Authorize]
        //public async Task<ActionResult<CustomResponseDTO>> ChangePassword([FromBody] ChangePasswordDTO requestData)
        //{
        //    var UserId = GetCurrentUserId();

        //    var result = await _mediator.Send(new ChangePassword { UserId = UserId, changePasswordData = requestData });
        //    return Ok(result);
        //}



    }
}