using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Product.Commands.Requests;
using BackendAssessment.Application.Features.Product.DTO.Validator;
using MediatR;


namespace BackendAssessment.Application.Features.Product.Commands.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommonResponse<int>>
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler
    (
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new CreateProductDtoValidator();

        var validationResult = await Validator.ValidateAsync(command.createCategoryDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to create product",
                error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        else
        {
            var product = _mapper.Map<Domain.Entities.Product>(command.createProductDto);
            var CreatedProduct = await _unitOfWork.ProductRepository.AddAsync(
                product
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(CreatedProduct.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to Create product");
            }
        }
    }
}