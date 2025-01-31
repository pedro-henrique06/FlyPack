using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Funcionario funcionario)
        {
            await _context.Set<Funcionario>().AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            _context.Set<Funcionario>().Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Funcionario>().FindAsync(id);
        }

        public async Task<List<Funcionario>> ObterTodosAsync()
        {
            return await _context.Set<Funcionario>().ToListAsync();
        }

        public async Task RemoverAsync(Funcionario funcionario)
        {
            _context.Set<Funcionario>().Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}
