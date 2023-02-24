using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.MapeamentoConfigs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios")
                .Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired(true);

            builder.ToTable("Usuarios")
                .Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .IsRequired(true);

            builder.ToTable("Usuarios")
                .Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(254)
                .IsRequired(true);

            builder.ToTable("Usuarios")
                .Property(u => u.RG)
                .HasColumnName("RG")
                .HasColumnType("nvarchar")
                .HasMaxLength(12)
                .HasDefaultValue(null);

            builder.ToTable("Usuarios")
                .Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(12)
                .IsRequired(true);

            builder.ToTable("Usuarios")
                .Property(u => u.NomeMae)
                .HasColumnName("NomeMae")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .HasDefaultValue(null);

            builder.ToTable("Usuarios")
                .Property(u => u.SituacaoCadastral)
                .HasColumnName("SituacaoCadastral")
                .HasColumnType("int")
                .HasDefaultValue(null);

            builder.ToTable("Usuarios")
                .Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasMaxLength(19)
                .IsRequired(true);

            builder.HasOne(u => u.Contato)
                .WithOne(c => c.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.EnderecosEntrega)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Departamentos)
                .WithMany(d => d.Usuarios)
                .UsingEntity(x => x.ToTable("UsuarioDepartamentos"));
        }
    }
}