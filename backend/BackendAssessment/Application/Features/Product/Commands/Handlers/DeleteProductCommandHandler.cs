using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos.Validators;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Features.Products.Commands.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var deleteProductValidator = new DeleteProductDtoValidator(_unitOfWork.UserRepository, _unitOfWork.ProductRepository);
        var validationResult = await deleteProductValidator.ValidateAsync(request.DeleteProductDto);

        if (validationResult.IsValid)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(request.DeleteProductDto.Id);
            await _unitOfWork.ProductRepository.DeleteAsync(product);
            int success = await _unitOfWork.SaveAsync();
            if (success > 0)
            {
                return CommonResponse<int>.Success(product.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("product Deletion Failed");
            }
        }
        else
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("product Deletion Failed", errorMessages);
        }
    }
}
