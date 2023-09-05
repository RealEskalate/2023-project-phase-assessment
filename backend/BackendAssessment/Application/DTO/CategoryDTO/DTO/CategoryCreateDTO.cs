using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CategoryDTO.DTO
{
    public class CategoryCreateDTO : IBaseCategoryDTO
    {
       public int Id {set;get;}
        public string? Name {get; set;}
        public string? Description {get; set;} 
    }
}
