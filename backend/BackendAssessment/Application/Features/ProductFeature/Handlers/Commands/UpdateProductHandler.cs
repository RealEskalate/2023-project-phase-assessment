
using Application.Features.ProductFeature.Requests.Commands;
using Application.Response;
using MediatR;
using Application.Contracts;
using AutoMapper;
using Application.DTO.ProductDTO.validations;
using Application.Exceptions;
using Application.DTO.ProductDTO.DTO;
namespace Application.Features.ProductFeature.Handlers.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseResponse<ProductResponseDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProductUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.ProductUpdateData!);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var Product = await _unitOfWork.ProductRepository.Get(request.Id);


            if (Product == null) 
            {
                throw new NotFoundException("Product is not found");
            }

            _mapper.Map(request.ProductUpdateData, Product);
            var updationResult = await _unitOfWork.ProductRepository.Update(Product);
            var result = _mapper.Map<ProductResponseDTO>(updationResult);
    
            return new BaseResponse<ProductResponseDTO> {
                Success = true,
                Message = "The Product is updated successfully",
                Value = result
            };
        }
    }
}
