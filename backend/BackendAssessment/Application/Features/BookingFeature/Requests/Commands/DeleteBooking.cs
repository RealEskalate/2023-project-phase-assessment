using Application.DTO.BookingDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingFeature.Requests.Commands
{
    public class DeleteBookingCommand : IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }
}
