using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ProductDto>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        
        return _mapper.Map<List<ProductDto>>(products);
    }
}