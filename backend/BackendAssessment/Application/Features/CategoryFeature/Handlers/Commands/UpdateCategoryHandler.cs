
using Application.Features.CategoryFeature.Requests.Commands;
using Application.Response;
using MediatR;
using Application.Contracts;
using AutoMapper;
using Application.DTO.CategoryDTO.validations;
using Application.Exceptions;
using Application.DTO.CategoryDTO.DTO;
namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseResponse<CategoryResponseDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CategoryUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.CategoryUpdateData!);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var Category = await _unitOfWork.CategoryRepository.Get(request.Id);


            if (Category == null) 
            {
                throw new NotFoundException("Category is not found");
            }

            _mapper.Map(request.CategoryUpdateData, Category);
            var updationResult = await _unitOfWork.CategoryRepository.Update(Category);
            var result = _mapper.Map<CategoryResponseDTO>(updationResult);
    
            return new BaseResponse<CategoryResponseDTO> {
                Success = true,
                Message = "The Category is updated successfully",
                Value = result
            };
        }
    }
}
