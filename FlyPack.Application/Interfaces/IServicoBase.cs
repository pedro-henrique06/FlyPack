namespace FlyPack.Application.Interfaces
{
    public interface IServicoBase<T> where T : class
    {
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(Guid id);
    }
}
