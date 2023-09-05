using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Queries.GetSingleProduct;

public class GetSingleProductHandler : IRequestHandler<GetSingleProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetSingleProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductDto> Handle(GetSingleProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSingleProductValidator(_productRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        return _mapper.Map<ProductDto>(product);
    }
}