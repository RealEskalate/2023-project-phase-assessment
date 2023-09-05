using Application.DTO.Users;
using Application.Features.Users.Request.Command;
using Application.Features.Users.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
       // private readonly IHttpContextAccessor _contextAccessor;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
           // _contextAccessor = httpContextAccessor;

        }

        [HttpGet("/users")]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
        {
            var request = new GetAllUserQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("/users/{id}")]
        public async Task<ActionResult<GetUserDto>> Get(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id});

            return user;
        }

        //create user
        [HttpPost("/Create users")]
        public async Task<ActionResult<GetUserDto>> Post(UserDto user)
        {
            var createdUser = await _mediator.Send(new CreateUserRequest { User = user });

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        //update user by UserDto
        [HttpPut("/Update users")]

        public async Task<ActionResult<GetUserDto>> Put(UserDto _user)
        {
            var updatedUser = await _mediator.Send(new UpdateUserRequest { user = _user });

            return Ok(updatedUser);
        }




    }
}
