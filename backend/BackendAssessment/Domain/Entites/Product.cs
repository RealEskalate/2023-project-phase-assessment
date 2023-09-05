namespace BackendAssessment.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Detail {get; set;}
    public bool Booked { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }

    public User User {get; set;}
    public Category Category {get; set;}
}