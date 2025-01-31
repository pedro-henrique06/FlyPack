using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            await _context.Set<Fornecedor>().AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            _context.Set<Fornecedor>().Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Fornecedor>().FindAsync(id);
        }

        public async Task<List<Fornecedor>> ObterTodosAsync()
        {
            return await _context.Set<Fornecedor>().ToListAsync();
        }

        public async Task RemoverAsync(Fornecedor fornecedor)
        {
            _context.Set<Fornecedor>().Remove(fornecedor);
            await _context.SaveChangesAsync();
        }
    }
}
