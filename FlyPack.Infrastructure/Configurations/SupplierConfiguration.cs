using FlyPack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.PersonType).IsRequired();
            builder.Property(s => s.CpfCnpj).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Phone);
            builder.Property(s => s.Address);
            builder.Property(s => s.Category).IsRequired();

            // Relacionamento com Product
            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .HasPrincipalKey(s => s.Id);

            builder.HasAnnotation("EFCore:ConstructorBinding", new[]
            {
                "Name", "PersonType", "CpfCnpj", "Email", "Phone", "Address", "Category"
            });
        }
    }


}
