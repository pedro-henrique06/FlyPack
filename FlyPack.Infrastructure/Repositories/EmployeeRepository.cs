using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Set<Employee>().AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _context.Set<Employee>().FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Set<Employee>().ToListAsync();
        }

        public async Task RemoveAsync(Employee employee)
        {
            _context.Set<Employee>().Remove(employee);
            await _context.SaveChangesAsync();
        }
    }


}
