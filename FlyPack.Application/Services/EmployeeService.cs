using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Employee entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Employee entity)
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
