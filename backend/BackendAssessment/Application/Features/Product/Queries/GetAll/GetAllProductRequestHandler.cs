using Application.Contracts;
using Application.Dtos.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetAll;

public class GetAllProductCommandHandler : IRequestHandler<GetAllProductRequest, IReadOnlyList<ProductResponseDto>>
{
    private IMapper _mapper;
    private IProductRepository _productRepository;
    public GetAllProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper; 
        _productRepository = productRepository;  
    }

    public async Task<IReadOnlyList<ProductResponseDto>> Handle(GetAllProductRequest command, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<IReadOnlyList<ProductResponseDto>>(products);
    }
}