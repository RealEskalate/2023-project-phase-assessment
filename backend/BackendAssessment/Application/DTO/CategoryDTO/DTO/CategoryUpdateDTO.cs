using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CategoryDTO.DTO
{
    public class CategoryUpdateDTO : IBaseCategoryDTO
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
    }
}
