using Application.Contracts;
using Application.Features.Category.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
            
    public UpdateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entites.Category>(request.CategoryDto);
        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}