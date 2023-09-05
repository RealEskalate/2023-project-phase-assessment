using Application.Contracts.Persistence;
using BackendAssessment.Application.Common.Exceptions;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Products.Requests.Commands;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductRequestHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken token)
    {
        var Product = await _productRepository.Get(request.Id);

        if (Product == null)
            throw new NotFoundException(nameof(Product), request.Id);
        
        await _productRepository.Delete(Product);

        return Unit.Value;
    }
}