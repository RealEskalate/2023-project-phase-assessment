using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Products.Dtos.Validators;
using Application.Features.Products.Queries.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new ProductDtoValidator(_unitOfWork);
        var validationResult = dtoValidator.Validate(request.CreateProductDto);

        if (validationResult.IsValid == false)
        {
            return CommonResponse<int>.FailureWithError(
                "Product creation failed.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            );
        }

        if (await _unitOfWork.UserRepository.ExistsAsync(request.CreateProductDto.UserId))
        {
            return CommonResponse<int>.FailureWithError(
                "Product creation failed.",
                "User does not exist."
            );
        }

        var createdProduct = _mapper.Map<Product>(request.CreateProductDto);
        var productId = await _unitOfWork.ProductRepository.AddAsync(createdProduct);

        if (await _unitOfWork.SaveAsync() > 0)
        {
            return new CommonResponse<int> {};
        }
        else
        {
            return CommonResponse<int>.Failure("Product creation failed.");
        }
    }
}
