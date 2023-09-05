using Application.Contracts;
using Application.Dtos.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAll;

public class GetAllCategoryRequestHandler : IRequestHandler<GetAllCategoryRequest, IReadOnlyList<CategoryResponseDto>>
{
    private IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    public GetAllCategoryRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper; 
        _categoryRepository = categoryRepository;  
    }

    public async Task<IReadOnlyList<CategoryResponseDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<IReadOnlyList<CategoryResponseDto>>(categories);
    }
}