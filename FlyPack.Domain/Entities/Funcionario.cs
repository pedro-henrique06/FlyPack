namespace FlyPack.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; private set; }
        public DateTime DataContratacao { get; private set; }

        public Funcionario(string nome, string tipoPessoa, string cpfCnpj, string email, string telefone, string endereco, string cargo, DateTime dataContratacao)
            : base(nome, tipoPessoa, cpfCnpj, email, telefone, endereco)
        {
            Cargo = cargo;
            DataContratacao = dataContratacao;
        }

        public void AtualizarCargo(string cargo)
        {
            Cargo = cargo;
        }
    }
}
