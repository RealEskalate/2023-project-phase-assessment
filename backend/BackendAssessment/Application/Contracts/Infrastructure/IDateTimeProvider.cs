namespace BackendAssessment.Application.Contracts.Infrastructure;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}