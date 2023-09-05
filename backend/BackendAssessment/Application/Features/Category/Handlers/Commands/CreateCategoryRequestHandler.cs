using Application.Contracts;
using Application.Dto.Category;
using Application.Features.Category.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, CategoryDto>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        
    public CreateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entites.Category>(request.CreateCategoryDto);
        var response = await _unitOfWork.CategoryRepository.AddAsync(category);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CategoryDto>(response);
    }
}