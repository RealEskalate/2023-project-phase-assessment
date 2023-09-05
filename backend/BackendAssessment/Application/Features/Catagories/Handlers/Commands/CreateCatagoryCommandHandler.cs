using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Application.DTOs.Catagory.Validators;
using Application.Features.Catagories.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Catagories.Handlers.Commands
{
    public class CreateCatagoryCommandHandler : IRequestHandler<CreateCatagoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCatagoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseCommandResponse> Handle(CreateCatagoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCatagoryDtoValidator();
            
            var validationResult = await validator.ValidateAsync(request.CreateCatagoryDto, cancellationToken);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var catagory = _mapper.Map<Catagory>(request.CreateCatagoryDto);
                catagory = await _unitOfWork.CatagoryRepository.Add(catagory);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = catagory.Id;
            }

            return response;
        }
    }
}