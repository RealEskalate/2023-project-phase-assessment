using Application.Contracts;
using Application.Dtos;
using Application.Features.Prodcut.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Prodcut.Handlers.Queries;

public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }
}