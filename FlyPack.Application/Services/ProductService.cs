using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Entities.Validators;
using FlyPack.Infrastructure.Repositories;

namespace FlyPack.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product entity)
        {
            // if (!ExecuteValidation(new ProductValidation(), product)) return;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.RemoveAsync(entity);
            }
        }

        public async Task<List<Product>> GetProductsWithSuppliersAsync()
        {
            return await _repository.GetProductsWithSuppliersAsync();
        }
    }

}
