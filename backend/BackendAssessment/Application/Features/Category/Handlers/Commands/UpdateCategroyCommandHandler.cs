using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Category.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Handlers.Commands
{
    public class UpdateCategroyCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategroyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var category = await _unitOfWork.categoryRepository.Get(request.categoryDto.Id);
                if (category is null) throw new NotFoundException(nameof(Category), request.categoryDto.Id);

                _mapper.Map(request.categoryDto, category);
                await _unitOfWork.categoryRepository.Update(category);

                if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something Went Wrong");


                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

            }
            catch (Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }

        }
    }
}
