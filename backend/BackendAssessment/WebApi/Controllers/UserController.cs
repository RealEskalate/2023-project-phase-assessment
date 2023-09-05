using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO.User;
using Application.Features.Users.Request.Command;
using Application.Features.Users.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDTO>>> GetAllUsers()
        {
            var request = new GetAllUsersRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetUserById(Guid id)
        {
            var request = new GetUserByIdRequest { Id = id };
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDTO updateUserDTO)
        {
            if (id != updateUserDTO.Id)
            {
                return BadRequest();
            }

            var command = new UpdateUserCommand { UpdateUserDTO = updateUserDTO };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDTO>> CreateUser(CreateUserDTO createUserDTO)
        {
            var command = new CreateUserCommand { CreateUserDTO = createUserDTO };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
