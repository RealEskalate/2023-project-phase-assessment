﻿using Application.DTO.BookingDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingFeature.Requests.Queries
{
    public class GetSingleBookingQuery : IRequest<BaseResponse<BookingResponseDTO>>
    {
        public int Id { get; set; }        
    }
}


