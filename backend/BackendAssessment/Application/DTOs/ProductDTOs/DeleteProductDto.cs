using ProductHub.Domain.Entities;

namespace ProductHub.Application.DTOs.ProductDtos;
public class DeleteProductDto
{
    public int Id{get; set;}   
    public int ActorId { get; set; }
    
}