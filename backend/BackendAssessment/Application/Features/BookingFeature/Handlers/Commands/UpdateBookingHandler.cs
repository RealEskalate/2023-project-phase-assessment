
using Application.Features.BookingFeature.Requests.Commands;
using Application.Response;
using MediatR;
using Application.Contracts;
using AutoMapper;
using Application.DTO.BookingDTO.validations;
using Application.Exceptions;
using Application.DTO.BookingDTO.DTO;
namespace Application.Features.BookingFeature.Handlers.Commands
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, BaseResponse<BookingResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateBookingHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseResponse<BookingResponseDTO>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new BookingUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.BookingUpdateData!);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var Booking = await _unitOfWork.BookingRepository.Get(request.Id);


            if (Booking == null) 
            {
                throw new NotFoundException("Booking is not found");
            }

            _mapper.Map(request.BookingUpdateData, Booking);
            var updationResult = await _unitOfWork.BookingRepository.Update(Booking);
            var result = _mapper.Map<BookingResponseDTO>(updationResult);
    
            return new BaseResponse<BookingResponseDTO> {
                Success = true,
                Message = "The Booking is updated successfully",
                Value = result
            };
        }
    }
}
