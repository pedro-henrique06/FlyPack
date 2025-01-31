namespace FlyPack.Presentation.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public Guid FornecedorId { get; set; }
        public string NomeFornecedor { get; set; } // Para exibir o nome do fornecedor associado
    }
}
