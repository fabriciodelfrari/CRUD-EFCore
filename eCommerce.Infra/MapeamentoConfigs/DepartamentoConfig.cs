using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.MapeamentoConfigs
{
    public class DepartamentoConfig : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamentos")
             .Property(d => d.Id)
             .HasColumnName("Id")
             .HasColumnType("int")
             .IsRequired(true);


            builder.ToTable("Departamentos")
              .Property(d => d.Nome)
              .HasColumnName("Nome")
              .HasColumnType("nvarchar")
              .HasMaxLength(30)
              .IsRequired(true);
        }
    }
}