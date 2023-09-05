using Application.Common;
using Application.Contracts;
using Application.Exceptions;
using Application.Features.ProductsFeature.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductsFeature.Handlers.Commands
{




    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var category = await _unitOfWork.CategoryRepository.Exists(request.Id);

            if (category == false)
            {
                throw new NotFoundException("category not found");
            }

            var rsult = await _unitOfWork.ProductRepository.Delete(request.Id);

            return new BaseResponse<string>()
            {
                Success = true,
                Message = "deleted successfully",
                Value = ""
            };

        }



    }
