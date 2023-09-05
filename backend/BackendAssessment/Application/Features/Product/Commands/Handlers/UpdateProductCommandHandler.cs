using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Product.Commands.Requests;
using BackendAssessment.Application.Features.Product.DTO.Validator;
using BackendAssessment.Domain.Entities;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Commands.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommonResponse<int>>
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new UpdateProductDtoValidator(_unitOfWork);

        var validationResult = await Validator.ValidateAsync(command.updateProductDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to update product",
                error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        else
        {
            var foundProduct = await _unitOfWork.ProductRepository.GetAsync(command.updateProductDto.Id);
            _mapper.Map(command.updateProductDto, foundProduct);
            await _unitOfWork.ProductRepository.UpdateAsync(
                foundProduct
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(foundProduct.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to update product");
            }
        }
    }
}