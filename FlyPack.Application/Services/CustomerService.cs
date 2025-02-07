using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Customer entity)
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
