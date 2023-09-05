using Application.Common;
using Application.Contracts;
using Application.Features.CategoryFeature.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Features.CategoryFeature.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await _unitOfWork.CategoryRepository.Exists(request.Id);

            if (category == false)
            {
                throw new NotFoundException("category not found");
            }

            var rsult = await _unitOfWork.CategoryRepository.Delete(request.Id);

            return new BaseResponse<string>()
            {
                Success = true,
                Message = "deleted successfully",
                Value = ""
            };

        }
    }
}
