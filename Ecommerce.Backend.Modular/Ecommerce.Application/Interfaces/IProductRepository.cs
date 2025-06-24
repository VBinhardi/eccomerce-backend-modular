using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
    }
}