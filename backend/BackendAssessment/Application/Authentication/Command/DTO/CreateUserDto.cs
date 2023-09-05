using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.User;


namespace Authentication.Command.DTO
{
    public class CreateUserDto:IUserDto
    {
    public string? Name { get; set; }
    public string? email { get; set; }
    public string? Bio { get; set; }
    public string? password { get; set; }
    }
}