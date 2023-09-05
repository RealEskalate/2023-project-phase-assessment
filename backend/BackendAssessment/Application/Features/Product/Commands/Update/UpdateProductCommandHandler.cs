using Application.Contracts;
using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponseDto>
{
    private IMapper _mapper;
    private IProductRepository _productRepository;
    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper; 
        _productRepository = productRepository;  
    }
    public async Task<ProductResponseDto> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductValidator();
        var validationResult = await validator.ValidateAsync(command.UpdateProduct, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var old_product = await _productRepository.GetSingleAsync(command.ProductId,cancellationToken);
        if(old_product == null)
            throw new Exception("product not found");
            
        var new_product = _mapper.Map<ProductEntity>(command.UpdateProduct);
        var updated_product = await _productRepository.UpdateAsync(old_product,new_product,cancellationToken);

        return _mapper.Map<ProductResponseDto>(updated_product);
    }
}