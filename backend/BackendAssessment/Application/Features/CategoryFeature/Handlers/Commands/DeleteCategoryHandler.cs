using Application.Contracts;
using Application.DTO.CategoryDTO.DTO;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public DeleteCategoryHandler(IUnitOfWork unitOfWork,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;

        }
        public async Task<BaseResponse<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = await _unitOfWork.CategoryRepository.Get(request.Id);
            if (Category == null) 
            {
                
                throw new NotFoundException("Category is not found");
                
            }

            
            var result = await _unitOfWork.CategoryRepository.Delete(Category);

            if (!result){
                throw new BadRequestException("The Category is not deleted");
            }


            return  new BaseResponse<int> {
                Success = true,
                Message = "The Category is deleted successfully",
                Value = Category.Id
            };
        }
    }
}
