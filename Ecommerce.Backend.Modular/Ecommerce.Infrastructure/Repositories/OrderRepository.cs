using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDbContext _context;

        private readonly IProductRepository _productRepository;
        public OrderRepository(IProductRepository productRepository, EcommerceDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<int> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync();
        }

        //AJUSTAR OS TIPOS DE RETORNO E TRATAR PRA UM DTO PRO CONTROLLER RECEBER ELES
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(i=>i.Items)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(i=>i.Items).
                FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
