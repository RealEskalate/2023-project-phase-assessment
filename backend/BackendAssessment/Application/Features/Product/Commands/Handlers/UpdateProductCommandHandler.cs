using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos.Validators;
using ProductHub.Domain.Entities;
namespace ProductHub.Application.Features.Products.Commands.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var updateValidator = new UpdateProductDtoValidator(_unitOfWork.UserRepository, _unitOfWork.CategoryRepository, _unitOfWork.ProductRepository);
        var validationResult = await updateValidator.ValidateAsync(request.UpdateProductDto);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("Product creation failed", errorMessages);
        }
        else
        {
            var product = _mapper.Map<Product>(request.UpdateProductDto);
            var updatedProduct = await _unitOfWork.ProductRepository.AddAsync(product);
            int success = await _unitOfWork.SaveAsync();

            if (success != 0)
            {
                return CommonResponse<int>.Success(updatedProduct.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Product Creation Failed");
            }
        }
    }
}
