using Ecommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDetailsDto> GetOrderByIdAsync(Guid id);
        Task<List<OrderDetailsDto>> GetAllOrdersAsync();
    }
}
