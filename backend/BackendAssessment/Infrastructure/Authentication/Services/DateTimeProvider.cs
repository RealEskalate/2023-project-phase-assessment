using Application.Common.Interface.Services;

namespace Infrastructure.Authentication.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}