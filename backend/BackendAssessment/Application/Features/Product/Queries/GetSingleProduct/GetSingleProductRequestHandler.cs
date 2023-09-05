using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetSingleProduct;

public class GetSingleProductRequestHandler : IRequestHandler<GetSingleProductRequest, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetSingleProductRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductResponseDto> Handle(GetSingleProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ProductResponseDto>(product);
    }
}