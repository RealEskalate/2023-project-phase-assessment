using Application.Contracts;
using Application.Dtos.Booking;
using Application.Exceptions;
using Application.Features.Booking.Commands;
using Application.Features.Booking.Validations;
using AutoMapper;
using MediatR;

namespace Application.Features.Booking.Handlers;

public class UpdateBookingCommandHanlder : IRequestHandler<UpdateBookingCommand, int>
{
    private  readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateBookingCommandHanlder(
        IBookingRepository bookingRepository, 
        IUserRepository userRepository, 
        IProductRepository productRepository, 
        IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
  
    public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBookingDtoValidator(_userRepository, _productRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateBookingDto, cancellationToken);

        if(validationResult.Errors.Count > 0)
            throw new ValidationErrorException(validationResult);
        
        var booking = await _bookingRepository.GetByIdAsync(request.UpdateBookingDto.Id) ?? throw new NotFoundException(nameof(Booking), request.UpdateBookingDto.Id);

        _mapper.Map(request.UpdateBookingDto, booking, typeof(UpdateBookingDto), typeof(Domain.Entities.Booking));
        await _bookingRepository.UpdateAsync(booking);
        return booking.Id;
    }
}