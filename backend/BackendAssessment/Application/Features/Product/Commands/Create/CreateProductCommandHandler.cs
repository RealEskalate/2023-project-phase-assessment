using Application.Contracts;
using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private IMapper _mapper;
    private IProductRepository _productRepository;
    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper; 
        _productRepository = productRepository;  
    }
    public async Task<ProductResponseDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductValidator();
        var validationResult = await validator.ValidateAsync(command.NewProduct, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var new_product = _mapper.Map<ProductEntity>(command.NewProduct);
        var created_product = await _productRepository.CreateAsync(new_product,cancellationToken);

        return _mapper.Map<ProductResponseDto>(created_product);
    }
}