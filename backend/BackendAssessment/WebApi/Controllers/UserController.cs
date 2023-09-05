using Application.Features.User.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;
using Application.Features.User.Request;
using Application.Features.User.Request.Queries;
using Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var command = new GetUsers();
            var token = await _mediator.Send(command);
            return ResponseHandler<List<UserDto>>.HandleResponse(token, 200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDTO updateUser)
        {
            var userId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            updateUser.Id = userId;
            var command = new UpdateUserCommand() { updateUser = updateUser };
            var token = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(token, 204);
        }
    }
}
