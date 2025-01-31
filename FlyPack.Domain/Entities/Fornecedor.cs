namespace FlyPack.Domain.Entities
{
    public class Fornecedor : Pessoa
    {
        public string Categoria { get; private set; } // Ex.: "Freelancer", "Empresa"

        public ICollection<Produto> Produtos { get; private set; }

        public Fornecedor(string nome, string tipoPessoa, string cpfCnpj, string email, string telefone, string endereco, string categoria)
            : base(nome, tipoPessoa, cpfCnpj, email, telefone, endereco)
        {
            Categoria = categoria;
            Produtos = new List<Produto>();
        }

        public void AtualizarCategoria(string categoria)
        {
            Categoria = categoria;
        }
    }
}
