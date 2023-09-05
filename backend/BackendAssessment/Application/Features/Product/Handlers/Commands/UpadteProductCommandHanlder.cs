using Application.Contracts;
using Application.Exceptions;
using Application.Features.Prodcut.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Prodcut.Handlers.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;
    
    public UpdateProductCommandHandler(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = _productRepository.GetByIdAsync(request.UpdateProductDto.Id).Result;

        if (productToUpdate == null)
        {
            throw new NotFoundException(nameof(Product), request.UpdateProductDto.Id);
        }

        _mapper.Map<Product>(request.UpdateProductDto);
       await  _productRepository.UpdateAsync(productToUpdate!);
        return Unit.Value;
    }
}