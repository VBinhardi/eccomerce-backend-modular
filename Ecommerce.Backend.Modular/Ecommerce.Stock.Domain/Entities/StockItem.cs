using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Stock.Domain.Entities
{
    public class StockItem
    {
        public Guid ProductId { get; set; }
        public int AvailableQuantity { get; set; }

        public void Decrease(int amount)
        {
            if (AvailableQuantity < amount)
                throw new InvalidOperationException("Insuficient stock.");

            AvailableQuantity -= amount;
        }

        public void Increase(int amount) { 
            AvailableQuantity += amount;
        }
    }
}
