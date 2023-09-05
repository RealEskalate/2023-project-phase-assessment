using Application.Contracts;
using Application.Features.Product.Requests.Command;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
                
    public DeleteProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductRepository.DeleteAsync(request.ProductId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}