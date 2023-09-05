using Application.Contracts;
using Application.DTOs.Category;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Queries.GetSingleCategory;

public class GetSingleCategoryHandler : IRequestHandler<GetSingleCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetSingleCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto> Handle(GetSingleCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSingleCategoryValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        
        return _mapper.Map<CategoryDto>(category);
    }
}