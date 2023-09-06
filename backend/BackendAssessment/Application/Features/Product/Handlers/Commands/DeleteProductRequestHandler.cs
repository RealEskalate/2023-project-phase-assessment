using Application.Contracts.Persistence;
using Application.DTOs.Product.Validators;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Features.Product.Handlers.Commands
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new DeleteProductDtoValidator(_unitOfWork);
            
          var validationResult = await validator.ValidateAsync(request.DeleteProductDto, cancellationToken);
  
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Domain.Entities.Product.Product>(request.DeleteProductDto);
              
                
              await _unitOfWork.ProductRepository.Delete(product);
          

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "deletion Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}