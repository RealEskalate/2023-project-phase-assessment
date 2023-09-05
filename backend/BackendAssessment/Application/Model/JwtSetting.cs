namespace Application.Model;
public class JwtSetting{
    public string Key { get; set; } = null!;      
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;      
    public double DurationInMinutes { get; set; }
}