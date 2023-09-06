using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs.Catergories;
using Application.Features.Categories.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;

namespace Application.Features.Categories.Handler.Queries
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, ErrorOr<List<CategoryResponseDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesRequestHandler(ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<ErrorOr<List<CategoryResponseDto>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            var categories = await _categoryRepository.GetAllCategories();

            return _mapper.Map<List<CategoryResponseDto>>(categories);
        }
    }
}