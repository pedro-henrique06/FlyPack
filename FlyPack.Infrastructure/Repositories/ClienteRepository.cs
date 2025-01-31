using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Set<Cliente>().Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Cliente>().FindAsync(id);
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task RemoverAsync(Cliente cliente)
        {
            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
