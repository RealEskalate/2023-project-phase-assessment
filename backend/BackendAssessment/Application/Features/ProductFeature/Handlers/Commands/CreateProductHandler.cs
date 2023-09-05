using System.Text.RegularExpressions;
using Application.Contracts;
using Application.DTO.ProductDTO.DTO;
using Application.DTO.ProductDTO.validations;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProductFeature.Handlers.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, BaseResponse<ProductResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateProductHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;

            
        }
        public async Task<BaseResponse<ProductResponseDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProductCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewProductData);
            var createProductResponse = new BaseResponse<ProductResponseDTO>();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var newProduct = _mapper.Map<Product>(request.NewProductData);

            var result = await _unitOfWork.ProductRepository.Add(newProduct);
            
            createProductResponse.Success = true;
            createProductResponse.Message = "Successfully Created Product";
            createProductResponse.Value = _mapper.Map<ProductResponseDTO>(result);

            return createProductResponse;


          
        }
    }
}
