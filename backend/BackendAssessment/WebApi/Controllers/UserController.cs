using Application.Dtos.User;
using Application.Features.User.Commands.Delete;
using Application.Features.User.Commands.Update;
using Application.Features.User.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [Route("GetSingleUser/{Id}")]
    public async Task<ActionResult<UserResponseDto>> GetSingleUser(Guid Id)
    {
        var user = await _mediator.Send(new GetSingleUserRequest{UserId = Id});
        return Ok(user);
    }
   
    [HttpPut()]
    [Route("UpdateUser/{Id}")]
    public async Task<ActionResult<UserResponseDto>> UpdateUser(Guid Id, UserRequestDto userUpdate)
    { 
        var res = await _mediator.Send(new UpdateUserCommand
        {
            UserId = Id,
            UpdateUser = userUpdate
        });

        return Ok(res);
    }
    
    [HttpDelete()]
    [Route("DeleteUser/{Id}")]
    public async Task<ActionResult> DeleteUser(Guid Id)
    { 
        var res = await _mediator.Send(new DeleteUserCommand{UserId = Id});

        return NoContent();
    }
}
