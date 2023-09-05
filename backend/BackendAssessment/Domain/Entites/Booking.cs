namespace BackendAssessment.Domain.Entities;
public class Booking : BaseEntity
{
    public Product Product{get; set;}
    public User User {get; set;}
}