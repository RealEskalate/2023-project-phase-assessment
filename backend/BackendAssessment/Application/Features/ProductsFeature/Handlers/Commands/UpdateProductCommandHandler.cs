using Application.Common;
using Application.Contracts;
using Application.DTO.Product.DTO;
using Application.DTO.Product.Validations;
using Application.Exceptions;
using Application.Features.ProductsFeature.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ProductResponseDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var validator = new ProductUpdateValidation(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.ProductData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }


            var product = await _unitOfWork.ProductRepository.GetbyId(request.ProductData.Id);

            _mapper.Map(request.ProductData , product);

            var result = await _unitOfWork.ProductRepository.Update(product);

            return new BaseResponse<ProductResponseDTO>()
            {
                Success = true,
                Message = "Product is updated successfully!",
                Value = _mapper.Map<ProductResponseDTO>(result)
            };

        }
    }
}
