using Application.Contracts;
using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private IMapper _mapper;
    private IProductRepository _productRepository;
    public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper; 
        _productRepository = productRepository;  
    }

    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetSingleAsync(command.ProductId,cancellationToken);
        if(product == null)
            throw new Exception("Product Id not found");
        await _productRepository.DeleteAsync(product,cancellationToken);
        return Unit.Value;
    }
}