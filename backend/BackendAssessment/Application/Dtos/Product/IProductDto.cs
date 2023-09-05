using Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public interface IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pricing { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
