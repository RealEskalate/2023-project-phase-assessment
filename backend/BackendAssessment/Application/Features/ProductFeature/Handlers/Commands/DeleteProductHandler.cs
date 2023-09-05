using Application.Contracts;
using Application.DTO.ProductDTO.DTO;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.ProductFeature.Handlers.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteProductHandler(IUnitOfWork unitOfWork,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;

        }
        public async Task<BaseResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var Product = await _unitOfWork.ProductRepository.Get(request.Id);
            if (Product == null) 
            {
                
                throw new NotFoundException("Product is not found");
                
            }

            
            var result = await _unitOfWork.ProductRepository.Delete(Product);

            if (!result){
                throw new BadRequestException("The Product is not deleted");
            }


            return  new BaseResponse<int> {
                Success = true,
                Message = "The Product is deleted successfully",
                Value = Product.Id
            };
        }
    }
}
