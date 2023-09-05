using Application.Contracts.Persistence;
using AutoMapper;
using BackendAssessment.Application.Common.Exceptions;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Application.Features.Products.Requests.Queries;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers.Queries;

public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken token)
    {
        var product = await _productRepository.Get(request.Id);
        if (product == null)
            throw new NotFoundException(nameof(Product), request.Id);
        return _mapper.Map<ProductDto>(product);
    }
}