using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repositorio;

        public FornecedorService(IFornecedorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Fornecedor>> ObterTodosAsync()
        {
            return await _repositorio.ObterTodosAsync();
        }

        public async Task<Fornecedor> ObterPorIdAsync(Guid id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Fornecedor entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public async Task AtualizarAsync(Fornecedor entidade)
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
    }
}
