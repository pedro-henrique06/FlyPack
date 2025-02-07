using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Set<Supplier>().AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Set<Supplier>().Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<Supplier> GetByIdAsync(Guid id)
        {
            return await _context.Set<Supplier>().FindAsync(id);
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Set<Supplier>().ToListAsync();
        }

        public async Task RemoveAsync(Supplier supplier)
        {
            _context.Set<Supplier>().Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }

}
