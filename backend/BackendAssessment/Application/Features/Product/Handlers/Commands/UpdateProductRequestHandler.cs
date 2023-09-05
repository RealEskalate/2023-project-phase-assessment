using Application.Contracts;
using Application.Features.Product.Requests.Command;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
            
    public UpdateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Entites.Product>(request.ProductCreationDto);
        await _unitOfWork.ProductRepository.UpdateAsync(product);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}