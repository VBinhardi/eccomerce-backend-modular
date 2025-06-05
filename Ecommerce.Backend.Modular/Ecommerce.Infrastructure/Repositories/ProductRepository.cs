using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductDto> _mockProducts = new()
    {
        new ProductDto { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Mouse Gamer", Price = 150 },
        new ProductDto { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Teclado Mecânico", Price = 300 },
        new ProductDto { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Monitor 144Hz", Price = 1200 }
    };
        public async Task<ProductDto> GetProductById(Guid id)
        {
            var product = _mockProducts.FirstOrDefault(i => i.Id == id);

            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            return product;
        }
    }
}
