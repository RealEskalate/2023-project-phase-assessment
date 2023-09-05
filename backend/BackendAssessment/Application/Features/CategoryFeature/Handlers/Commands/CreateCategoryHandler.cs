using System.Text.RegularExpressions;
using Application.Contracts;
using Application.DTO.CategoryDTO.DTO;
using Application.DTO.CategoryDTO.validations;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<CategoryResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;

            
        }
        public async Task<BaseResponse<CategoryResponseDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CategoryCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewCategoryData!);
            var createCategoryResponse = new BaseResponse<CategoryResponseDTO>();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var newCategory = _mapper.Map<Category>(request.NewCategoryData);

            var result = await _unitOfWork.CategoryRepository.Add(newCategory);
            
            createCategoryResponse.Success = true;
            createCategoryResponse.Message = "Successfully Created Category";
            createCategoryResponse.Value = _mapper.Map<CategoryResponseDTO>(result);

            return createCategoryResponse;


          
        }
    }
}
