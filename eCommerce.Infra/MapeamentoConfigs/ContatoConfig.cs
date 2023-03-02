using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.MapeamentoConfigs
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
             builder.ToTable("Contatos")
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired(true);

            builder.ToTable("Contatos")
               .Property(c => c.UsuarioId)
               .HasColumnName("UsuarioId")
               .HasColumnType("int")
               .IsRequired(true);

            builder.ToTable("Contatos")
               .Property(c => c.Telefone)
               .HasColumnName("Telefone")
               .HasColumnType("nvarchar")
               .HasMaxLength(10)
               .HasDefaultValue(null);

            builder.ToTable("Contatos")
               .Property(c => c.Celular)
               .HasColumnName("Celular")
               .HasColumnType("nvarchar")
               .HasMaxLength(11)
               .HasDefaultValue(null);
            
            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
            //builder.HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}