using BackendAssessment.Application.Contracts.Infrastructure;

namespace BackendAssessment.Infrastructure.DateTimeService;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
