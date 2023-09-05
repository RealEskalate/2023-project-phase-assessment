using Application.Contracts.Persistence;
using Application.Dtos.ProductDto.Validator;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse<Unit?>>
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Unit?>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try{
            var validator = new UpdateProductDtoValidator(_unitOfWork.ProductRepository);
            var validationResult = await validator.ValidateAsync(request.updateProduct);
            if (!validationResult.IsValid){
                throw new ValidationException(validationResult);
            }

            var product = await _unitOfWork.ProductRepository.Get(request.updateProduct.Id);
            var user = await _unitOfWork.UserRepository.Get(request.UserId);
            _mapper.Map(request.updateProduct, product);
            if (product.UserId != request.UserId && user.Role != Role.Admin)
            {
                throw new BadRequestException("You are Unauthtized to do this");
            }
            
            await _unitOfWork.ProductRepository.Update(product);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit?>.SuccessHandler(Unit.Value);
        }
        catch(Exception ex){
            return BaseCommandResponse<Unit?>.FailureHandler(ex);
        }
    }
}
