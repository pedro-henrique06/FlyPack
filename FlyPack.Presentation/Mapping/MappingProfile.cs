using AutoMapper;
using FlyPack.Domain.Entities;
using FlyPack.Presentation.ViewModels;

namespace FlyPack.Presentation.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Supplier <-> SupplierViewModel
            CreateMap<Supplier, SupplierViewModel>().ReverseMap()
                .ConstructUsing(src => new Supplier(src.Name, src.PersonType, src.CpfCnpj, src.Email, src.Phone, src.Address, src.Category));

            // Map Customer <-> CustomerViewModel
            CreateMap<Customer, CustomerViewModel>().ReverseMap()
                .ConstructUsing(src => new Customer(src.Name, src.PersonType, src.CpfCnpj, src.Email, src.Phone, src.Address, src.Notes));

            // Map Employee <-> EmployeeViewModel
            CreateMap<Employee, EmployeeViewModel>().ReverseMap()
                .ConstructUsing(src => new Employee(src.Name, src.PersonType, src.CpfCnpj, src.Email, src.Phone, src.Address, src.Position, src.HireDate));

            // Map Product <-> ProductViewModel
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ReverseMap()
                .ConstructUsing(src => new Product(src.Name, src.Description, src.Price, src.SupplierId));

        }
    }
}
