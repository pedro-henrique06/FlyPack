using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repositorio;

        public ClienteService(IClienteRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            return await _repositorio.ObterTodosAsync();
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Cliente entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public async Task AtualizarAsync(Cliente entidade)
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
