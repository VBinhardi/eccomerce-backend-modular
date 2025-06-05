using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductService _productService;
        public ProductService(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductDto> GetProductById(Guid id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            return product;
        }
    }
}
