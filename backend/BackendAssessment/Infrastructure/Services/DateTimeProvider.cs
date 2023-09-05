using Backend.Application.Common.Interface.Services;

namespace Backend.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}