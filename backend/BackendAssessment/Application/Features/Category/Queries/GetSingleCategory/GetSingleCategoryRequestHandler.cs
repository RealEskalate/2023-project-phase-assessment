using Application.Contracts;
using Application.DTOs.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetSingleCategory;

public class GetSingleCategoryRequestHandler : IRequestHandler<GetSingleCategoryRequest, CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetSingleCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryResponseDto> Handle(GetSingleCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CategoryResponseDto>(category);
    }
}