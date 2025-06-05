using Ecommerce.Application.DTOs;
using Ecommerce.Stock.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IProductRepository _productRepository;
        public OrderRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<OrderDetailsDto> _mockDB = new List<OrderDetailsDto>();

        public async Task<Guid> AddAsync(CreateOrderDto dto)
        {
            var items = await Task.WhenAll(dto.Items.Select(async i =>
            {
                var product = await _productRepository.GetProductById(i.ProductId);

                return new OrderItemDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = i.Quantity,
                    UnitPrice = product.Price
                };
            }));

            var order = new OrderDetailsDto
            {
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                Items = items.ToList(),
            };

            _mockDB.Add(order);
            return order.Id;
        }

        public async Task<List<OrderDetailsDto>> GetAllAsync()
        {
            return _mockDB;
        }

        public async Task<OrderDetailsDto?> GetByIdAsync(Guid id)
        {
            return _mockDB.FirstOrDefault(i => i.Id == id);
        }
    }
}
