using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public decimal Total => Items.Sum(x => x.Quantity*x.UnitPrice);
        public DateTime CreatedAt { get; set; }
    }
}
