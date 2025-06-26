using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Events
{
    public class OrderCreated
    {
        public Guid Id { get; set; }
        public List<ProductQuantityDto> Items { get; set; }
    }
}
