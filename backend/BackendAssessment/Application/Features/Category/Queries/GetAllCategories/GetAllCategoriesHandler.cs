using Application.Contracts;
using Application.DTOs.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesCommand, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();

        return _mapper.Map<List<CategoryDto>>(categories);
    }
}