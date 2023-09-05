using Application.Contracts;
using Application.Dtos.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetSingle;

public class GetSingleCategoryRequestHandler : IRequestHandler<GetSingleCategoryRequest, CategoryResponseDto>
{
    private IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    public GetSingleCategoryRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper; 
        _categoryRepository = categoryRepository;  
    }

    public async Task<CategoryResponseDto> Handle(GetSingleCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetSingleAsync(request.CategoryId,cancellationToken);
        if(category == null)
            throw new Exception("Category Id not found");
        
        return _mapper.Map<CategoryResponseDto>(category);
    }
}