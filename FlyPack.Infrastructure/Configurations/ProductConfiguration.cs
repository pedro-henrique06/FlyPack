using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FlyPack.Domain.Entities;

namespace FlyPack.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description);

            // Definindo o tipo da coluna Price para decimal(18,2)
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            // Relacionamento com Supplier
            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .HasPrincipalKey(s => s.Id);

            builder.HasAnnotation("EFCore:ConstructorBinding", new[] { "Name", "Description", "Price", "SupplierId" });
        }
    }

}
