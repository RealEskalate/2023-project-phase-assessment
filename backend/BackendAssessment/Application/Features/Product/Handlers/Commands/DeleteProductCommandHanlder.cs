using Application.Contracts;
using Application.Features.Prodcut.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Prodcut.Handlers.Commands;

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
        var productToDelete = await _productRepository.GetByIdAsync(request.Id);
        await _productRepository.DeleteAsync(productToDelete);
        return Unit.Value;
    }
}