using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Events
{
    public class ProductQuantityDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
