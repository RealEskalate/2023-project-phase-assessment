using Application.Contracts;
using Application.Dtos.Category.Valiation;
using Application.Exceptions;
using Application.Features.Cateogory.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cateogory.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken)
    {

        var validator = new CreateCategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(createCategoryCommand.CreateCategory, cancellationToken);
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationErrorException(validationResult);
        }

        var category = _mapper.Map<Category>(createCategoryCommand.CreateCategory);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }
}