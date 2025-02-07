using FlyPack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlyPack.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            // Herda propriedades da classe Person
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PersonType).IsRequired();
            builder.Property(e => e.CpfCnpj).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Phone);
            builder.Property(e => e.Address);

            // Propriedades específicas de Employee
            builder.Property(e => e.Position).IsRequired();
            builder.Property(e => e.HireDate).IsRequired();

            builder.HasAnnotation("EFCore:ConstructorBinding", new[]
            {
                "Name", "PersonType", "CpfCnpj", "Email", "Phone", "Address", "Position", "HireDate"
            });
        }
    }

}
