using FlyPack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            // Herda propriedades da classe Person
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.PersonType).IsRequired();
            builder.Property(c => c.CpfCnpj).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Phone);
            builder.Property(c => c.Address);

            // Propriedade específica de Customer
            builder.Property(c => c.Notes);

            builder.HasAnnotation("EFCore:ConstructorBinding", new[]
            {
                "Name", "PersonType", "CpfCnpj", "Email", "Phone", "Address", "Notes"
            });
        }
    }

}
