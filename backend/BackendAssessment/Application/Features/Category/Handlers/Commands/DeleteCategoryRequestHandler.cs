using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.DTOs.Product.Validators;
using Application.Features.Category.Requests.Commands;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Features.Product.Handlers.Commands
{
    public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new DeleteCategoryDtoValidator(_unitOfWork);
            
          var validationResult = await validator.ValidateAsync(request.DeleteCategoryDto, cancellationToken);
  
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Domain.Entities.Category.Category>(request.DeleteCategoryDto);
              
                
              await _unitOfWork.CategoryRepository.Delete(category);
          

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "deletion Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}