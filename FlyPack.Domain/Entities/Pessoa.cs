using System.ComponentModel.DataAnnotations;

namespace FlyPack.Domain.Entities
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; protected set; }
        public string TipoPessoa { get; protected set; }
        public string CpfCnpj { get; protected set; }
        public string Email { get; protected set; }
        public string Telefone { get; protected set; }
        public string Endereco { get; protected set; }
        public bool Ativo { get; protected set; } = true;

        protected Pessoa(string nome, string tipoPessoa, string cpfCnpj, string email, string telefone, string endereco)
        {
            Nome = nome;
            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void AtualizarDados(string nome, string email, string telefone, string endereco)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
