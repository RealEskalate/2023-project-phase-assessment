using Application.Common;
using Application.Contracts;
using Application.DTO.Category.DTO;
using Application.DTO.Category.Validations;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<CategoryResponseDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validator = new CategoryUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.CategoryData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }


            var category = await _unitOfWork.CategoryRepository.GetbyId(request.CategoryData.Id);
            _mapper.Map(request.CategoryData, category);

            var result = await _unitOfWork.CategoryRepository.Update(category);

            return new BaseResponse<CategoryResponseDTO>()
            {
                Success = true,
                Message = "Categoriy is updated Successfully",
                Value = _mapper.Map<CategoryResponseDTO>(result)
            };
        }
    }
}
