using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Category
{
    public interface ICategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
