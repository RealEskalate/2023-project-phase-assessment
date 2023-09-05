using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _unitOfWork.productRepository.Get(request.Product.Id);
                _mapper.Map(request.Product, post);
                await _unitOfWork.productRepository.Update(post);
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
