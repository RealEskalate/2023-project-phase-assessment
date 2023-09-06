using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.User;
using Application.Features.Users.Request.Command;
using Application.Features.Users.Request.Queries;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateUserDto>> GetUserById(Guid id)
        {
            var request = new GetUserRequest { Id = id };
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, CreateUserDto userDTO)
        {
            
            var command = new UpdateUserCommand { UserName = userDTO.username,Password = userDTO.password,Email = userDTO.email };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser(CreateUserDto UserDTO)
        {
            var command = new CreateUserCommand { name = UserDTO.username, password = UserDTO.password, email = UserDTO.email,isAdmin = UserDTO.isAdmin };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}

