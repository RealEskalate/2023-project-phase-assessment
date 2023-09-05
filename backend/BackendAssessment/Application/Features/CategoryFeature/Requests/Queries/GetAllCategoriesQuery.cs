﻿using Application.Common;
using Application.DTO.Category.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeature.Requests.Queries
{
    public class GetAllCategoriesQuery : IRequest<BaseResponse<List<CategoryResponseDTO>>>
    {
    }
}
