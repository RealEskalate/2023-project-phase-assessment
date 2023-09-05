using Application.Contracts;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validation = new DeleteProductCommandValidator(_productRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var product = await _productRepository.GetByIdAsync(request.ProductId);
        await _productRepository.DeleteAsync(product!.Id);
        return Unit.Value;
    }
}