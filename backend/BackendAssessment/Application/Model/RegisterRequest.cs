using System.ComponentModel.DataAnnotations;

namespace Application.Model;


public class RegisterRequest{
    [Required(ErrorMessage = "Email Is Required")]
    public string Email{get;set;}
    [Required(ErrorMessage = "Username Required")]
    public string UserName{get;set;}

    public string Role{ get; set; } = "user";
    [Required(ErrorMessage = "Password Is Required")]
    public string Password {get;set;}

}