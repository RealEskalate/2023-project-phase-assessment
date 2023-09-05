namespace Domain.Entites;

public class User{
    public string Id{ set; get; }
    public string Username{ set; get; }
    public string Email{ set; get; }
    public string Role{ set; get; } = "user";
}