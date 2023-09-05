using ProductHub.Application.Contracts.Infrastructure;

namespace ProductHub.Infrastructure.DateTimeService;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}