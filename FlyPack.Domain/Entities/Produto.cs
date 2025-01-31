namespace FlyPack.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public bool Ativo { get; private set; } = true;

        // Relacionamento com Fornecedor
        public Guid FornecedorId { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        public Produto(string nome, string descricao, decimal preco, int estoque, Guid fornecedorId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            FornecedorId = fornecedorId;
        }

        public void AtualizarProduto(string nome, string descricao, decimal preco, int estoque, Guid fornecedorId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            FornecedorId = fornecedorId;
        }

        public void AtualizarEstoque(int quantidade)
        {
            Estoque += quantidade;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
