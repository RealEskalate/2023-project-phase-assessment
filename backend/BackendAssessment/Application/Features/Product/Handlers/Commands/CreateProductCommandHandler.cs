using Application.Contracts.Persistance;
using Application.DTO.ProductDTO.Validator;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<BaseCommandResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateProductDtoValidator();
                var validationResult = await validator.ValidateAsync(request.Product);
                if (!validationResult.IsValid) throw new ValidationException(validationResult);

                var post = _mapper.Map<Domain.Entites.Product>(request.Product);
                await _unitOfWork.productRepository.Add(post);
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");


                return BaseCommandResponse<int>.SuccessHandler(post.Id);
            }
            catch (Exception ex)
            {
                return BaseCommandResponse<int>.FailureHandler(ex);
            }


        }
    }
}
