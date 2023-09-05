using Application.Contracts.Persistance;
using Application.DTO.ProductCategoryDTO.Validator;
using Application.Exceptions;
using Application.Features.ProductCategory.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductCategory.Handlers.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validation = new ProductCategoryDtoValidator();
                var validationResult = await validation.ValidateAsync(request.ProductCategoryDto);
                if (!validationResult.IsValid) throw new ValidationException(validationResult);

                var productCategory = _mapper.Map<Domain.Entites.ProductCategory>(request.ProductCategoryDto);
                await _unitOfWork.productCategoryRepository.AddProductToCategory(request.ProductCategoryDto.ProductId, request.ProductCategoryDto.CategoryId);
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");


                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
            }
            catch (Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }
        }
    }
}
