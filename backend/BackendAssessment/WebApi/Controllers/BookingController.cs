using Application.Dtos.Booking;
using Application.Features.Booking.Commands;
using Application.Features.Booking.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BookingController : ControllerBase{
    private readonly IMediator _mediator;
    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingDto createBookingDto){
        var result = await _mediator.Send(new CreateBookingCommand(){CreateBookingDto = createBookingDto});
        
        return Created(string.Empty, result);

    }

   

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        var result = await _mediator.Send(new GetAllBookingsByUserIdQuery(){UserId = id});
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateBookingDto updateBookingDto){
         await _mediator.Send(new UpdateBookingCommand(){ UpdateBookingDto = updateBookingDto});
        return NoContent();
    }

    
}