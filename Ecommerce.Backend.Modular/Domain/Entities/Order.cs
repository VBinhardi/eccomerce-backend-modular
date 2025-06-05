using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total => Items.Sum(x => x.UnitPrice * x.Quantity);
        public DateTime CreatedAt { get; set; }
    }
}
