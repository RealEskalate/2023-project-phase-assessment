using System.Security.Claims;

using Application.DTO.BookingDTO.DTO;
using Application.Features.BookingFeature.Requests.Commands;
using Application.Features.BookingFeature.Requests.Queries;
using Application.Features.ProductFeature.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<BookingResponseDTO>>>> Get()
        {   
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetAllBookingQuery());
            return Ok(result);    
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BookingResponseDTO>>> Get(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetSingleBookingQuery());
            return Ok(result);            
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BookingResponseDTO>>> CreateBooking([FromBody] BookingCreateDTO newBookingData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new CreateBookingCommand{ NewBookingData = newBookingData});
           

            return Ok(result);            
        }
   
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BookingResponseDTO>>> UpdateBooking(int id, [FromBody] BookingUpdateDTO UpdateBookingData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateBookingCommand { Id = id, BookingUpdateData = UpdateBookingData});
            
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BaseResponse<int>>>> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteBookingCommand {Id = id });    
                   
            return Ok(result);
            
        }
        
    }
}
