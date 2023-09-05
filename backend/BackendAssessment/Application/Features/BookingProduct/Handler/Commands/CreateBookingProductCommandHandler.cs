using Application.Common;
using Application.Contracts;
using Application.DTO.BookingProduct.DTO;
using Application.DTO.BookingProduct.Validation;
using Application.Exceptions;
using Application.Features.BookingProduct.Request.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingProduct.Handler.Commands
{
    public class CreateBookingProductCommandHandler : IRequestHandler<CreateBookingProductCommand, BaseResponse<BookProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<BookProductDTO>> Handle(CreateBookingProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new BookingValidation(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BookingData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var product = await _unitOfWork.ProductRepository.GetbyId(request.BookingData.ProductId);

            if (product.Quantity < request.BookingData.Quantity)
            {
                throw new BadRequestException("Your booking Quantity is more than the available quantity");
            }

            product.Quantity = product.Quantity - request.BookingData.Quantity;
            await _unitOfWork.ProductRepository.Update(product);


            var newBooking = _mapper.Map<BookProduct>(request.BookingData);
            var result = await _unitOfWork.BookingProductRepository.Add(newBooking);

            return new BaseResponse<BookProductDTO>()
            {
                Success = true,
                Message = "Booked successfully",
                Value = _mapper.Map<BookProductDTO>(result)
            };
        }
    }
}
