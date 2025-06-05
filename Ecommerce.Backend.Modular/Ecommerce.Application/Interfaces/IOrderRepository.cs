using Ecommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Stock.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<Guid> AddAsync(CreateOrderDto dto);
        Task<OrderDetailsDto?> GetByIdAsync(Guid id);
        Task<List<OrderDetailsDto>> GetAllAsync();
    }
}
