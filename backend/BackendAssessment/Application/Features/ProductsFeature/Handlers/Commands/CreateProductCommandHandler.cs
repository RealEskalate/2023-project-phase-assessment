using Application.Common;
using Application.Contracts;
using Application.DTO.Product.DTO;
using Application.DTO.Product.Validations;
using Application.Exceptions;
using Application.Features.ProductsFeature.Requests.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<ProductResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ProductResponseDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var validator = new ProductCreateValidation(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.ProductData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }


            var newProduct = _mapper.Map<Product>(request.ProductData);


            Console.WriteLine("the new product is :", newProduct);


            await _unitOfWork.ProductRepository.Add(newProduct);
            await _unitOfWork.Save();




            return new BaseResponse<ProductResponseDTO>()
            {
                Success = true,
                Message = "The Product is Created Successfully",
                Value = _mapper.Map<ProductResponseDTO>(newProduct)
            };
        }
    }
}
