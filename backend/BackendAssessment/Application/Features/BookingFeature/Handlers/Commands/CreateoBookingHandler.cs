using System.Text.RegularExpressions;
using Application.Contracts;
using Application.DTO.BookingDTO.DTO;
using Application.DTO.BookingDTO.validations;
using Application.Exceptions;
using Application.Features.BookingFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.BookingFeature.Handlers.Commands
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, BaseResponse<BookingResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateBookingHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;

            
        }
        public async Task<BaseResponse<BookingResponseDTO>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new BookingCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewBookingData!);
            var createBookingResponse = new BaseResponse<BookingResponseDTO>();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var newBooking = _mapper.Map<Booking>(request.NewBookingData);

            var result = await _unitOfWork.BookingRepository.Add(newBooking);
            
            createBookingResponse.Success = true;
            createBookingResponse.Message = "Successfully Created Booking";
            createBookingResponse.Value = _mapper.Map<BookingResponseDTO>(result);

            return createBookingResponse;


          
        }
    }
}
