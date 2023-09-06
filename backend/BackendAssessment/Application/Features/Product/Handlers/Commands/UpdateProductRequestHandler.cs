using Application.Contracts.Persistence;
using Application.DTOs.Product.Validators;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Features.Product.Handlers.Commands
{
    public class  UpdateProductRequestHandler: IRequestHandler<UpdateProductRequest, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateProductDtoValidator(_unitOfWork);
            
          var validationResult = await validator.ValidateAsync(request.UpdateProductDto, cancellationToken);
  
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Domain.Entities.Product.Product>(request.UpdateProductDto);
               
                
             await _unitOfWork.ProductRepository.Update(product);
          
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "updated Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}