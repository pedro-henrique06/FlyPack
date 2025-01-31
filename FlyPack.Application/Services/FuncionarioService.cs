using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repositorio;

        public FuncionarioService(IFuncionarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Funcionario>> ObterTodosAsync()
        {
            return await _repositorio.ObterTodosAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(Guid id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Funcionario entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public async Task AtualizarAsync(Funcionario entidade)
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
