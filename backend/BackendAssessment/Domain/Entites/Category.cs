using BackendAssessment.Domain.Common;

namespace BackendAssessment.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = null!;
}