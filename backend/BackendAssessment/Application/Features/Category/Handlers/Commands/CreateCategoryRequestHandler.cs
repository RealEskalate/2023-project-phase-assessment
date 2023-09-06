using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.DTOs.Product.Validators;
using Application.Features.Category.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest , BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ICategoryDtoValidator();
            
          var validationResult = await validator.ValidateAsync(request.ICategoryDto, cancellationToken);
  
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Domain.Entities.Category.Category>(request.ICategoryDto);
                
                await _unitOfWork.CategoryRepository.Add(category);
              

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}