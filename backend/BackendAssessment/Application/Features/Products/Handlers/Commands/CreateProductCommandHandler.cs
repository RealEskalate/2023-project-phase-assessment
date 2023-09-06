using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Product.Validators;
using Application.Features.Products.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator(_unitOfWork);
            
            var validationResult = await validator.ValidateAsync(request.CreateProductDto, cancellationToken);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Product>(request.CreateProductDto);
                
                var catagory = await _unitOfWork.CatagoryRepository.Get(product.CatagoryId);
                catagory?.Products.Add(product);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}