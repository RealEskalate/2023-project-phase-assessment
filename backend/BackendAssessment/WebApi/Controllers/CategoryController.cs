using Application.Dtos;
using Application.Features.Cateogory.Commands;
using Application.Features.Cateogory.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase{

    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto){
        var result = await _mediator.Send(new CreateCategoryCommand(){CreateCategory = createCategoryDto});
        Console.WriteLine(result);
        Console.WriteLine("------------------------------------------------");
        return Created(string.Empty, result);

    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var result = await _mediator.Send(new GetAllCategoriesRequest());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        var result = await _mediator.Send(new GetCategoryByIdRequest(){Id = id});
        //print result
        Console.WriteLine(result);
        Console.WriteLine("------------------------------------------------");
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto){
         await _mediator.Send(new UpdateCategoryCommand(){ UpdateCategoryDto = updateCategoryDto});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
         await _mediator.Send(new DeleteCategoryCommand(){Id = id});
        return NoContent();
    }
}
