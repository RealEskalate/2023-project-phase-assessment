using Application.Common;
using Application.Contracts;
using Application.DTO.Category.DTO;
using Application.DTO.Category.Validations;
using Application.DTO.Product.Validations;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<CategoryResponseDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CategoryCreateValidation();
            var validationResult = await validator.ValidateAsync(request.CategoryData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }


            var categoryExist = await _unitOfWork.CategoryRepository.CategoryExist(request.CategoryData.Name);

            if (categoryExist)
            {
                throw new BadRequestException("Category Already Exist, no need to create it again");
            }


            var newCategory = _mapper.Map<Category>(request.CategoryData);

            var result = await _unitOfWork.CategoryRepository.Add(newCategory);

            return new BaseResponse<CategoryResponseDTO> {
                Success = true,
                Message = "Category Created SUccessfully",
                Value = _mapper.Map<CategoryResponseDTO>(result)
            };
      }
    }
}
