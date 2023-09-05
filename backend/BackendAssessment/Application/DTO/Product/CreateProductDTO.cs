namespace Application.DTO;

public class CreateProductDTO
{
    public required string Name  { get; set; }
    public required string Description { get; set; }
    public required bool Availability { get; set; }
    public required string Password { get; set; }
    public string Bio { get; set; } = "";
}