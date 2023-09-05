using Application.Contracts;
using Application.Dtos;
using Application.Exceptions;
using Application.Features.Prodcut.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Prodcut.Handlers.Queries;

public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var DoesExist = await _productRepository.ExistsAsync(request.Id);

        if (!DoesExist)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        var product = await _productRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ProductDto>(product);
    }
}