using FlyPack.Domain.Entities;

namespace FlyPack.Application.Interfaces
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<List<Product>> GetProductsWithSuppliersAsync();
    }

}
