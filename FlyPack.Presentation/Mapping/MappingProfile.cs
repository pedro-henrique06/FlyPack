using AutoMapper;
using FlyPack.Domain.Entities;
using FlyPack.Presentation.ViewModels;

namespace FlyPack.Presentation.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapear Fornecedor <-> FornecedorViewModel
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap()
                .ConstructUsing(src => new Fornecedor(src.Nome, src.TipoPessoa, src.CpfCnpj, src.Email, src.Telefone, src.Endereco, src.Categoria));

            // Mapear Cliente <-> ClienteViewModel
            CreateMap<Cliente, ClienteViewModel>().ReverseMap()
                .ConstructUsing(src => new Cliente(src.Nome, src.TipoPessoa, src.CpfCnpj, src.Email, src.Telefone, src.Endereco, src.Observacoes));

            // Mapear Funcionario <-> FuncionarioViewModel
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap()
                .ConstructUsing(src => new Funcionario(src.Nome, src.TipoPessoa, src.CpfCnpj, src.Email, src.Telefone, src.Endereco, src.Cargo, src.DataContratacao));

            // Mapear Produto <-> ProdutoViewModel
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome))
                .ReverseMap()
                .ConstructUsing(src => new Produto(src.Nome, src.Descricao, src.Preco, src.Estoque, src.FornecedorId));
        }
    }
}
