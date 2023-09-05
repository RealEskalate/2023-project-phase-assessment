using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Products.Dtos.Validators;
using Application.Features.Products.Queries.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers.Commands;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, CommonResponse<Unit>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Unit>> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new ProductDtoValidator(_unitOfWork);
        var validationResult = dtoValidator.Validate(request.UpdateProductDto);

        if (validationResult.IsValid == false)
        {
            return CommonResponse<Unit>.FailureWithError(
                "Product updation failed.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            );
        }

        if (request.UpdateProductDto.UserId != request.UserId)
        {
            return CommonResponse<Unit>.FailureWithError(
                "Product updation failed.",
                "User not authorized to update this product."
            );
        }

        var updatedProduct = _mapper.Map<Product>(request.UpdateProductDto);
        await _unitOfWork.ProductRepository.UpdateAsync(
            request.UpdateProductDto.Id,
            updatedProduct
        );

        if (await _unitOfWork.SaveAsync() > 0)
        {
            return new CommonResponse<Unit> { };
        }
        else
        {
            return CommonResponse<Unit>.Failure("Product updation failed.");
        }
    }
}
