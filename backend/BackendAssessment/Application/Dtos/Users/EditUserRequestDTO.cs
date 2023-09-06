using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Users
{
    public class EditUserRequestDTO
    {
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? Bio { get; init; } = "";
        public IFormFile? Picture { get; set; }
    }
}