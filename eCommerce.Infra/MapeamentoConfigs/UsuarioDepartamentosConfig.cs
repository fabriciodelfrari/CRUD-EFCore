using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.MapeamentoConfigs
{
    public class UsuarioDepartamentosConfig : IEntityTypeConfiguration<UsuarioDepartamentos>
    {
        public void Configure(EntityTypeBuilder<UsuarioDepartamentos> builder)
        {
             builder.ToTable("UsuarioDepartamentos")
             .Property(ud => ud.Id)
             .HasColumnName("Id")
             .HasColumnType("int")
             .IsRequired(true);

            builder.ToTable("UsuarioDepartamentos")
            .Property(ud => ud.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("int")
            .IsRequired(true);

            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
            //builder.HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}