using Application.DTOs.Category;
using Application.DTOs.Common;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class GetProductDto:BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public GetUserDto User { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
