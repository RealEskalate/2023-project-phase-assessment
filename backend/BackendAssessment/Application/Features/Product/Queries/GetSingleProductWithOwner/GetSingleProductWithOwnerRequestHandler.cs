using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;

namespace Application.Features.Product.Queries.GetSingleProductWithOwner;

public class GetSingleProductWithOwnerRequestHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public GetSingleProductWithOwnerRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductResponseDto> Handle(GetSingleProductWithOwnerRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetSingleProductWithOwner(request.ProductId);
        return _mapper.Map<ProductResponseDto>(product);
    }
}