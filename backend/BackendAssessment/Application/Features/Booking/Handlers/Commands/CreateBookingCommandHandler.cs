using System.ComponentModel.DataAnnotations;
using Application.Contracts;
using Application.Dtos.Booking;
using Application.Dtos.Category.Valiation;
using Application.Exceptions;
using Application.Features.Booking.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Booking.Handlers;

public class CreateBookingCommandHanlder : IRequestHandler<CreateBookingCommand, int>
{
    private  readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateBookingCommandHanlder(IBookingRepository bookingRepository, IUserRepository userRepository, IProductRepository productRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBookingDtoValidator(_userRepository, _productRepository);
        var validationResult = await validator.ValidateAsync(request.CreateBookingDto, cancellationToken);

        
        if(validationResult.Errors.Count > 0)
            throw new ValidationErrorException(validationResult);
        
        var booking = _mapper.Map<Domain.Entities.Booking>(request.CreateBookingDto);
        await _bookingRepository.AddAsync(booking);
        return booking.Id;
    }
}