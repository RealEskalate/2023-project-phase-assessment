using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.SearchProductsByNameAndDesc;

public class SearchProductsByNameAndDescQueryHandler : IRequestHandler<SearchProductsByNameAndDescQuery, List<ProductResponseDto>>
{
    private readonly IProductRepository _tagRepository;
    private readonly IMapper _mapper;
    
    public SearchProductsByNameAndDescQueryHandler(IProductRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ProductResponseDto>> Handle(SearchProductsByNameAndDescQuery request, CancellationToken cancellationToken)
    {
        var products = await _tagRepository.SearchProductsByNameAndDesc(request.Name);
        return _mapper.Map<List<ProductResponseDto>>(products);
    }
}