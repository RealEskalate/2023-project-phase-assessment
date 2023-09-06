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
    public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest , BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateCategoryDtoValidator(_unitOfWork);
            
          var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto, cancellationToken);
  
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Domain.Entities.Category.Category>(request.UpdateCategoryDto);
                
                await _unitOfWork.CategoryRepository.Update(category);
              

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "Update Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}