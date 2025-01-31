namespace FlyPack.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public string Observacoes { get; private set; }

        public Cliente(string nome, string tipoPessoa, string cpfCnpj, string email, string telefone, string endereco, string observacoes)
            : base(nome, tipoPessoa, cpfCnpj, email, telefone, endereco)
        {
            Observacoes = observacoes;
        }

        public void AtualizarObservacoes(string observacoes)
        {
            Observacoes = observacoes;
        }
    }
}
