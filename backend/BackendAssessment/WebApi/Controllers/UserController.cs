using Application.Dtos;
using Application.Features.User.Requests.Commands;
using Application.Features.User.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase{


    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto createUserDto){
        var result = await _mediator.Send(new CreateUserCommand(){CreateUserDto = createUserDto});
        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var result = await _mediator.Send(new GetAllUsersRequest());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        var result = await _mediator.Send(new GetUserByIdRequest(){Id = id});
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateUserDto updateUserDto){
         await _mediator.Send(new UpdateUserCommand(){ UpdateUserDto = updateUserDto});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
         await _mediator.Send(new DeleteUserCommand(){Id = id});
        return NoContent();
    }
}