using Application.Dtos;
using Application.Features.Prodcut.Requests.Commands;
using Application.Features.Prodcut.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdcutController : ControllerBase{
    private readonly IMediator _mediator;

    public ProdcutController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto){
        var result = await _mediator.Send(new CreateProductCommand(){CreateProductDto = createProductDto});
        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var result = await _mediator.Send(new GetAllProductsRequest());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        var result = await _mediator.Send(new GetProductByIdRequest(){Id = id});
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateProductDto updateProductDto){
         await _mediator.Send(new UpdateProductCommand(){ UpdateProductDto = updateProductDto});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
       await _mediator.Send(new DeleteProductCommand(){Id = id});
        return NoContent();
    }
}