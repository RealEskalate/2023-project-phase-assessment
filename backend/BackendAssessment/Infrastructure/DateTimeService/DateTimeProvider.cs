namespace Infrastructure.DateTimeService;

using Application.Contracts.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
