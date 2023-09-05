using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.DTO.CategoryDTO.Validator;
using Application.Exceptions;
using Application.Features.Category.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateCategoryValidator();
                var validationResult = await validator.ValidateAsync(request.categoryDto);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult);
                }

                var category = _mapper.Map<Domain.Entites.Category>(request.categoryDto);

                await _unitOfWork.categoryRepository.Add(category);

                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");
                return BaseCommandResponse<int>.SuccessHandler(category.Id);
            }
            catch (Exception ex)
            {
                return BaseCommandResponse<int>.FailureHandler(ex);
            }
        }
    }
}
