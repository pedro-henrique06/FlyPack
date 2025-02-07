using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Supplier> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Supplier entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Supplier entity)
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
    }

}
