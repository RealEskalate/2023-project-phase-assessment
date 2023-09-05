using Application.DTOs.User;
using Application.Features.User.Commands.DeleteUser;
using Application.Features.User.Commands.ToggleUserRole;
using Application.Features.User.Queries.GetAllUsers;
using Application.Features.User.Queries.GetSingleUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> Get(int id)
        {
            return await _mediator.Send(new GetSingleUserRequest
            {
                Id = id
            });
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersRequest());
            return users;
        }

        [HttpGet("toggleUserRole/{id:int}")]
        public async Task<ActionResult<UserResponseDto>> ToggleUserRole(int id)
        {
            await AuthHelper.OnlyAdminUser(User);
            
            return await _mediator.Send(new ToggleUserRoleCommand()
            {
                UserId = id
            });
        }
        
        [HttpDelete("{id:int}")]
        public async Task DeleteUser(int id)
        {
            await AuthHelper.CheckUserById(User, id);
            
            await _mediator.Send(new DeleteUserCommand
            {
                UserId = id
            });
        }
    }
}
