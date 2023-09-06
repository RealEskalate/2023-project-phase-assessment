using ErrorOr;
using Application.DTOs.Users;
// using Application.Features.
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.Request.Command;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class PasswordRecoveryController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public PasswordRecoveryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("{token}")]
        public async Task<ActionResult> UpdatePasswordWithToken(string token, [FromBody] UpdatePasswordTokenRequestDTO updatePasswordTokenRequestDTO)
        {
            UpdatePasswordTokenRequest request = new UpdatePasswordTokenRequest()
            {
                updatePasswordTokenRequestDTO = updatePasswordTokenRequestDTO,
                Token = token
            };

            ErrorOr<string> result = await _mediator.Send(request);

            return result.Match<ActionResult>(
                success => Ok(success),
                error => BadRequest(error)
            );
        }
    }
}
