using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos.Validators;
using ProductHub.Domain.Entities;
namespace ProductHub.Application.Features.Products.Commands.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createValidator = new CreateProductDtoValidator(_unitOfWork.UserRepository, _unitOfWork.CategoryRepository);
        var validationResult = await createValidator.ValidateAsync(request.CreateProductDto);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("Product creation failed", errorMessages);
        }
        else
        {
            var Product = _mapper.Map<Product>(request.CreateProductDto);
            var newProduct = await _unitOfWork.ProductRepository.AddAsync(Product);
            int success = await _unitOfWork.SaveAsync();

            if (success != 0)
            {
                return CommonResponse<int>.Success(newProduct.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Product Creation Failed");
            }
        }
    }
}
