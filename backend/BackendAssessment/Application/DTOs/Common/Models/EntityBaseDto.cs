namespace Application.DTOs.Common.Models;

public abstract class EntityBaseDto {
    public EntityBaseDto(Guid id) => Id = id;

    public EntityBaseDto() {}

    public Guid Id { get; set; }
}
