using Ecommerce.Application.DTOs;

namespace Ecommerce.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductById(Guid id);
    }
}