namespace BackendAssessment.Application.Features.Product.DTO;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Price { get; set; }

    public int? CategoryId { get; set; }

    public int? Available {get; set;}
}