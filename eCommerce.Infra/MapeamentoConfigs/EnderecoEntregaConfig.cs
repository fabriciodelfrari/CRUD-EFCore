using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.MapeamentoConfigs
{
    public class EnderecoEntregaConfig : IEntityTypeConfiguration<EnderecoEntrega>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntrega> builder)
        {
            builder.ToTable("EnderecosEntrega")
               .Property(e => e.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(e => e.UsuarioId)
               .HasColumnName("UsuarioId")
               .HasColumnType("int")
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.NomeEndereco)
               .HasColumnName("NomeEndereco")
               .HasColumnType("nvarchar")
               .HasMaxLength(20)
               .HasDefaultValue(null);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.CEP)
               .HasColumnName("CEP")
               .HasColumnType("nvarchar")
               .HasMaxLength(8)
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.Estado)
               .HasColumnName("Estado")
               .HasColumnType("nvarchar")
               .HasMaxLength(2)
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.Estado)
               .HasColumnName("Estado")
               .HasColumnType("nvarchar")
               .HasMaxLength(2)
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.Cidade)
               .HasColumnName("Cidade")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
              .Property(c => c.Bairro)
              .HasColumnName("Bairro")
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
               .Property(c => c.Endereco)
               .HasColumnName("Endereco")
               .HasColumnType("nvarchar")
               .HasMaxLength(60)
               .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
              .Property(c => c.Numero)
              .HasColumnName("Numero")
              .HasColumnType("nvarchar")
              .HasMaxLength(8)
              .IsRequired(true);

           builder.ToTable("EnderecosEntrega")
             .Property(c => c.Complemento)
             .HasColumnName("Complemento")
             .HasColumnType("nvarchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);

            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
           //builder.HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}