using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace BackendAssessment.Persistence.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(AssessmentDbContext context) : base(context)
    {
    }

    
}