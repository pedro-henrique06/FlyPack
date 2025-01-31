namespace FlyPack.Presentation.ViewModels
{
    public class FornecedorViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string TipoPessoa { get; set; } // "Física" ou "Jurídica"
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Categoria { get; set; } // Ex.: "Freelancer", "Empresa"
    }
}
