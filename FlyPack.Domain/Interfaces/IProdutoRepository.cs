using FlyPack.Domain.Entities;
using FlyPack.Domain.Interfaces;

namespace FlyPack.Infrastructure.Repositories
{
    public interface IProdutoRepository : IRepositorioBase<Produto>
    {
        Task<List<Produto>> ObterProdutosComFornecedoresAsync();
    }
}
