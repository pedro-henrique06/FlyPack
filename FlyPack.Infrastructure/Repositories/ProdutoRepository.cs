using FlyPack.Domain.Entities;
using FlyPack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Produto entidade)
        {
            await _context.Set<Produto>().AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto entidade)
        {
            _context.Set<Produto>().Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Produto>().FindAsync(id);
        }

        public async Task<List<Produto>> ObterProdutosComFornecedoresAsync()
        {
            return await _context.Produtos
                .Include(p => p.Fornecedor)
                .ToListAsync();
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Set<Produto>().ToListAsync();
        }

        public async Task RemoverAsync(Produto entidade)
        {
            _context.Set<Produto>().Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
