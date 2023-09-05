using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.BookingProduct.DTO
{
    public class BookProductDTO
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
