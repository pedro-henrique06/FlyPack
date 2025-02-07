using FlyPack.Domain.Entities;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Set<Product>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Set<Product>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task<List<Product>> GetProductsWithSuppliersAsync()
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task RemoveAsync(Product entity)
        {
            _context.Set<Product>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}
