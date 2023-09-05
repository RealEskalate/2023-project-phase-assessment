using Domain.Common;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public required int UserId { get; set; }

    public required int CategoryId { get; set; }

    public required decimal Price { get; set; }

    public required bool IsAvailable { get; set; }


    public virtual Category Category { get; set; } = default!;

    public virtual User User { get; set; } = default!;

}
