namespace Application.DTO.ProductDTO;

public class ProductListDTO{
    public int Id { get; set; }
    public string Name { get; set; }
    // public string Description { get; set; }
    public float Pricing{ get; set; }
    public int Availability { get; set; }
    
    public int CategoryId{ get; set; }
    public string UserId { get; set; }
    
    // public virtual Category Category{ get; set; }
    // public virtual ApplicaionUser User{ get; set; }
    
}