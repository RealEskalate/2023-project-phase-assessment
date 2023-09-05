using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.ProductCategory.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;

namespace Application.Features.ProductCategory.Handlers.Commands
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.productCategoryRepository.RemoveProductFromCategory(request.ProductCategoryDto.ProductId, request.ProductCategoryDto.CategoryId);
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
            }
            catch (Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }
        }
    }
}

