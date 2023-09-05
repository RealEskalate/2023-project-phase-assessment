using Application.DTO.BookingDTO.DTO;
using Application.Response;
using MediatR;


namespace Application.Features.BookingFeature.Requests.Commands
{
    public class CreateBookingCommand : IRequest<BaseResponse<BookingResponseDTO>>
    {
        public BookingCreateDTO? NewBookingData { get; set; }
    }
}
