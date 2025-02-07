using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Infrastructure.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<List<Product>> GetProductsWithSuppliersAsync();
    }
}
