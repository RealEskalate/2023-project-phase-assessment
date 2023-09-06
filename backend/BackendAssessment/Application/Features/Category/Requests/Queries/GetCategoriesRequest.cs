using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.DTOs.Product;
using MediatR;
namespace Application.Features.Category.Requests.Queries;
public record GetCategoriesRequest() : IRequest<List<CategoryDto>>;