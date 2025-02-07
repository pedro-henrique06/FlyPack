using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Set<Customer>().AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task RemoveAsync(Customer customer)
        {
            _context.Set<Customer>().Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

}
