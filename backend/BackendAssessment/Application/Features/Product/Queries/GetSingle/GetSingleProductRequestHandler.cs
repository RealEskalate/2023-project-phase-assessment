using Application.Contracts;
using Application.Dtos.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetSingle;

public class GetSingleProductCommandHandler : IRequestHandler<GetSingleProductRequest, ProductResponseDto>
{
    private IMapper _mapper;
    private IProductRepository _productRepository;
    public GetSingleProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper; 
        _productRepository = productRepository;  
    }

    public async Task<ProductResponseDto> Handle(GetSingleProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetSingleAsync(request.ProductId,cancellationToken);
        if(product == null)
            throw new Exception("Product Id not found");
        
        return _mapper.Map<ProductResponseDto>(product);
    }
}