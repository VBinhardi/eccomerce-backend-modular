using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.Events;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Interfaces.Messaging;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly IEventPublisher _eventPublisher;
        public OrderService(IOrderRepository orderRepository, IProductService productService, IEventPublisher publisher)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _eventPublisher = publisher;
        }


        public async Task<Guid> CreateOrderAsync(CreateOrderDto dto)
        {
            var Items = new List<OrderItem>();
            Guid orderId = Guid.NewGuid();

            foreach (var item in dto.Items)
            {
                var product = await _productService.GetProductByIdAsync(item.ProductId);

                Items.Add(new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                });
            }

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Id = orderId,
                Items = Items
            };

            await _orderRepository.AddAsync(order);

            var eventDto = new OrderCreated { Id = orderId , Items = order.Items.Select(i =>
            {
                return new ProductQuantityDto
                {
                    Quantity = i.Quantity,
                    Id = i.Id
                };
            }).ToList()};

            await _eventPublisher.PublishAsync(eventDto);
            return orderId;
        }

        public async Task<List<OrderDetailsDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(x =>
            {
                return new OrderDetailsDto
                {
                    CreatedAt = x.CreatedAt,
                    Id = x.Id,
                    Items = x.Items.Select(item => new OrderItemDto
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                    }).ToList(),
                };
                 
            }).ToList();
        }

        public async Task<OrderDetailsDto?> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                throw new KeyNotFoundException("Order not found.");
            
            return new OrderDetailsDto
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Items = order.Items.Select(i=> new OrderItemDto
                {
                    ProductId=i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice 
                }).ToList(),
            };
        }
    }
}
