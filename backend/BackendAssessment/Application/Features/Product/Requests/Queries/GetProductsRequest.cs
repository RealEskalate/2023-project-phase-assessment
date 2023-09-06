using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using MediatR;
namespace Application.Features.Product.Requests.Queries;
public record GetProductsRequest() : IRequest<List<ProductDto>>;