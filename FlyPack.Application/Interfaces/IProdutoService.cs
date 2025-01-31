using FlyPack.Domain.Entities;

namespace FlyPack.Application.Interfaces
{
    public interface IProdutoService : IServicoBase<Produto>
    {
        Task<List<Produto>> ObterProdutosComFornecedoresAsync();
    }
}
