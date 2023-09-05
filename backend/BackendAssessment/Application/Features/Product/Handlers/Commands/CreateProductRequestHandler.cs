using Application.Contracts;
using Application.Dto.Product;
using Application.Features.Product.Requests.Command;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Features.Product.Handlers.Commands;

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        
    public CreateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Entites.Product>(request.ProductCreationDto);
        var response = await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductDto>(response);
    }
}