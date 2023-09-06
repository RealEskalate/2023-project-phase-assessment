using Application.Contracts;
using Application.DTOs.Products;
using Application.DTOs.Products.Validators;
using Application.Features.Products.Request.Command;
using AutoMapper;
using Domain.Entites;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Handler.Command
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, ErrorOr<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<ProductResponseDto>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new ProductDtoValidator();
            var validationResult = validator.Validate(request.ProductDetailDto);

            if (!validationResult.IsValid)
            {
                return Errors.Product.InvalidProduct;
            }

            var user = await _userRepository.GetUserById(request.UserId);
            
            // check if user exists
            if(user == null){
                return Errors.User.UserNotFound;
            }

            // check if user is admin
            if(user.IsAdmin == false)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            var category = _categoryRepository.GetCategoryById(request.CategoryId);

            // check if category exists
            if(category == null){
                return Errors.Category.CategoryNotFound;
            }

            var product = _mapper.Map<Product>(request);
            var createdProduct = await _productRepository.AddProduct(product);

            var response = _mapper.Map<ProductResponseDto>(createdProduct);
            return response;
        }
    }
}