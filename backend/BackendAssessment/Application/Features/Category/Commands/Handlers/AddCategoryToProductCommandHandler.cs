using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Category.DTO.validator;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Handlers;

public class AddCategoryToProductCommandHandler: IRequestHandler<AddCategroryToProductCommand, CommonResponse<int>>
{
     private IUnitOfWork _unitOfWork;
     private IMapper _mapper;

     public AddCategoryToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
     {
          _unitOfWork = unitOfWork;
          _mapper = mapper;
     }

   

     public async Task<CommonResponse<int>> Handle(AddCategroryToProductCommand command, CancellationToken cancellationToken)
     {
          var response = new CommonResponse<int>();
          var Validator = new AddCategoryDtoValidator(_unitOfWork);

          var validationResult = await Validator.ValidateAsync(command.addCategoryDto);

          if (!validationResult.IsValid)
          {
               return CommonResponse<int>.FailureWithError(message: "failed to create product",
                    error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
          }

          else
          {
               var foundProduct = await _unitOfWork.ProductRepository.GetAsync(command.addCategoryDto.ProductId);
               foundProduct.CategoryId = command.addCategoryDto.CategoryId;
               await _unitOfWork.ProductRepository.UpdateAsync(
                    foundProduct
               );
              
               if (await _unitOfWork.SaveAsync() > 0)
               {
                    return CommonResponse<int>.Success(foundProduct.Id);
               }
               else
               {
                    return CommonResponse<int>.Failure("Failed to Create product");
               }
          }
     }
}