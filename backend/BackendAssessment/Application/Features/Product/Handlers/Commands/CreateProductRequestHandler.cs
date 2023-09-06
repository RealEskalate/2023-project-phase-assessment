using Application.Contracts.Persistence;
using Application.DTOs.Product.Validators;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Features.Product.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
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
                var product = _mapper.Map<Domain.Entities.Product.Product>(request.CreateProductDto);
                product.UserId = request.UserId;
                
                var category = await _unitOfWork.CategoryRepository.Get(product.CategoryId);
              category.Products.Add(product);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}