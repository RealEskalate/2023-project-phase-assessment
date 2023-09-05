using Application.Contracts;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var product = _mapper.Map<ProductEntity>(request.ProductDto);
        var user = await _userRepository.GetByIdAsync(request.ProductOwnerId);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        product.ProductOwner = user;
        product.Category = category;
        var res = await _productRepository.CreateAsync(product);
        return _mapper.Map<ProductResponseDto>(res);
    }
}