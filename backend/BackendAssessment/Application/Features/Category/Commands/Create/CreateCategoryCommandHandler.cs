using Application.Contracts;
using Application.Dtos.Category;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper; 
        _categoryRepository = categoryRepository;  
    }
    public async Task<CategoryResponseDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator();
        var validationResult = await validator.ValidateAsync(command.NewCategory, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var new_category = _mapper.Map<CategoryEntity>(command.NewCategory);
        var created_category = await _categoryRepository.CreateAsync(new_category,cancellationToken);

        return _mapper.Map<CategoryResponseDto>(created_category);
    }
}