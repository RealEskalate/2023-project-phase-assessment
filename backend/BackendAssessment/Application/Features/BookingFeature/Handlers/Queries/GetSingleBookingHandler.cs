using Application.Contracts;
using Application.DTO.BookingDTO.DTO;
using Application.Exceptions;
using Application.Features.BookingFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;


namespace Application.Features.BookingFeature.Handlers.Queries
{
    public class GetSingleBookingHandler : IRequestHandler<GetSingleBookingQuery, BaseResponse<BookingResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleBookingHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<BookingResponseDTO>> Handle(GetSingleBookingQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookingRepository.Get(request.Id);
            if (result == null)
            {
                throw new NotFoundException("Booking is not found");
            }

            var Booking = _mapper.Map<BookingResponseDTO>(result);
            
            return new BaseResponse<BookingResponseDTO>{
                Success = true,
                Message = "Booking is retrieved successfully",
                Value = Booking
            };
            
        }
    }
}
