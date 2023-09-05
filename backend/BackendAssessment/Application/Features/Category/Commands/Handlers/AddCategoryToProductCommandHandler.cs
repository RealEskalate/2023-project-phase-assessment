using AutoMapper;
using BackendAssessment.Application.Contracts.Persistence;

namespace BackendAssessment.Application.Features.Category.Commands.Handlers;

public class AddCategoryToProductCommandHandler
{
     private IUnitOfWork _unitOfWork;
     private IMapper _mapper;

     public AddCategoryToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
     {
          _unitOfWork = unitOfWork;
          _mapper = mapper;
     }
     
}