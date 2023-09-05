using Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.ProductDtos;
using AutoMapper;
using MediatR;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Application.Features.Products.Requests.Queries;

namespace BackendAssessment.Application.Features.Products.Handlers.Queries;

public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken token)
    {
        var products = await _productRepository.GetAll();

        return _mapper.Map<List<ProductDto>>(products);
    }

   
}