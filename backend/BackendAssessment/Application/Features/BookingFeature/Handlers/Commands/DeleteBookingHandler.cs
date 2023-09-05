using Application.Contracts;
using Application.DTO.BookingDTO.DTO;
using Application.Exceptions;
using Application.Features.BookingFeature.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.BookingFeature.Handlers.Commands
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteBookingHandler(IUnitOfWork unitOfWork,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;

        }
        public async Task<BaseResponse<int>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var Booking = await _unitOfWork.BookingRepository.Get(request.Id);
            if (Booking == null) 
            {
                
                throw new NotFoundException("Booking is not found");
                
            }

            
            var result = await _unitOfWork.BookingRepository.Delete(Booking);

            if (!result){
                throw new BadRequestException("The Booking is not deleted");
            }


            return  new BaseResponse<int> {
                Success = true,
                Message = "The Booking is deleted successfully",
                Value = Booking.Id
            };
        }
    }
}
