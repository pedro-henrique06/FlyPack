using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Entities.Validators;
using FlyPack.Infrastructure.Repositories;

namespace FlyPack.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repositorio;

        public ProdutoService(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _repositorio.ObterTodosAsync();
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Produto entidade)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _repositorio.AdicionarAsync(entidade);
        }

        public async Task AtualizarAsync(Produto entidade)
        {
            await _repositorio.AtualizarAsync(entidade);
        }

        public async Task RemoverAsync(Guid id)
        {
            var entidade = await _repositorio.ObterPorIdAsync(id);
            if (entidade != null)
            {
                await _repositorio.RemoverAsync(entidade);
            }
        }

        public async Task<List<Produto>> ObterProdutosComFornecedoresAsync()
        {
            return await _repositorio.ObterProdutosComFornecedoresAsync();
        }
    }
}
