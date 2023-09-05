using Application.Common;
using Application.DTO.BookingProduct.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingProduct.Request.Commands
{
    public class CreateBookingProductCommand : IRequest<BaseResponse<BookProductDTO>>
    {
        public BookProductDTO BookingData { get; set; }
    }
}
