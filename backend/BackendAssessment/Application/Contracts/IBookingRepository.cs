using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        
    }
}