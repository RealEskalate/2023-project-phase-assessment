using Application.Contracts.Persistence;
using Application.Dtos.ProductDto.Validator;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<int?>>
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<int?>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try{
            var validator = new CreateProductDtoValidator(_unitOfWork.CategoryRepository);
            var validationResult = await validator.ValidateAsync(request.CreateProduct);
            if (!validationResult.IsValid){
                throw new ValidationException(validationResult);
            }

            var product = _mapper.Map<Domain.Entites.Product>(request.CreateProduct);
            await _unitOfWork.ProductRepository.Add(product);
            if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<int?>.SuccessHandler(product.Id);
        }
        catch(Exception ex){
            return BaseCommandResponse<int?>.FailureHandler(ex);
        }
    }
}