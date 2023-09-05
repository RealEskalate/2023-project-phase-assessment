using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Catagory.Validators;
using Application.Exceptions;
using Application.Features.Catagories.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Catagories.Handlers.Commands
{
    public class UpdateCatagoryCommandHandler : IRequestHandler<UpdateCatagoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCatagoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateCatagoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCatagoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCatagoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            
            var catagory = await _unitOfWork.CatagoryRepository.Get(request.UpdateCatagoryDto.Id);

            if (catagory is null)
                throw new NotFoundException(nameof(catagory), request.UpdateCatagoryDto.Id);
            
            // if (product.UserId != request.RequestingUserId)
            //     throw new UnauthorizedAccessException("User is not authorized.");
            
            _mapper.Map(request.UpdateCatagoryDto, catagory);

            await _unitOfWork.CatagoryRepository.Update(catagory);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value; 
        }
    }
}