using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Product.Validators;
using Application.Exceptions;
using Application.Features.Products.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.UpdateProductDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            
            var product = await _unitOfWork.ProductRepository.Get(request.UpdateProductDto.Id);

            if (product is null)
                throw new NotFoundException(nameof(product), request.UpdateProductDto.Id);
            
            // if (product.UserId != request.RequestingUserId)
            //     throw new UnauthorizedAccessException("User is not authorized.");
            
            _mapper.Map(request.UpdateProductDto, product);

            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value; 
        }
    }
}