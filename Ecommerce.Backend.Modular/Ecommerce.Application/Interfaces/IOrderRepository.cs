using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order order);
        Task<Order> GetByIdAsync(Guid id);
        Task<List<Order>> GetAllAsync();
    }
}
