using Application.Contracts;
using Application.Features.Category.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Unit>
{
     
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        
    public DeleteCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CategoryRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}