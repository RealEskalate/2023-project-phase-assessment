using Application.Contracts;
using Application.Dtos.Category;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponseDto>
{
    private IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper; 
        _categoryRepository = categoryRepository;  
    }
    public async Task<CategoryResponseDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryValidator();
        var validationResult = await validator.ValidateAsync(command.UpdateCategory, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var old_category = await _categoryRepository.GetSingleAsync(command.CategoryId,cancellationToken);
        if(old_category == null)
            throw new Exception("category not found");
            
        var new_category = _mapper.Map<CategoryEntity>(command.UpdateCategory);
        var updated_category = await _categoryRepository.UpdateAsync(old_category,new_category,cancellationToken);

        return _mapper.Map<CategoryResponseDto>(updated_category);
    }
}