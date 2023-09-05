using Application.Contracts;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Features.Product.Commands.CreateProduct;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _productRepository;
    private readonly IMapper _mapper;
    
    public CreateCategoryCommandHandler(ICategoryRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var product = _mapper.Map<CategoryEntity>(request.CategoryDto);
        var res = await _productRepository.CreateAsync(product);
        return _mapper.Map<CategoryResponseDto>(res);
    }
}