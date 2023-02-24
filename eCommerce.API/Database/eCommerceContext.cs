using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<UsuarioDepartamentos> UsuarioDepartamentos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tabela Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired(true);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .IsRequired(true);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(254)
                .IsRequired(true);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.RG)
                .HasColumnName("RG")
                .HasColumnType("nvarchar")
                .HasMaxLength(12)
                .HasDefaultValue(null);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(12)
                .IsRequired(true);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.NomeMae)
                .HasColumnName("NomeMae")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .HasDefaultValue(null);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.SituacaoCadastral)
                .HasColumnName("SituacaoCadastral")
                .HasColumnType("int")
                .HasDefaultValue(null);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasMaxLength(19)
                .IsRequired(true);

            modelBuilder.Entity<Usuario>().HasOne(u => u.Contato);
            modelBuilder.Entity<Usuario>().HasMany(u => u.EnderecosEntrega);
            modelBuilder.Entity<Usuario>().HasMany(u => u.Departamentos);
            #endregion

            #region Tabela Contatos

            modelBuilder.Entity<Contato>().ToTable("Contatos")
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired(true);

            modelBuilder.Entity<Contato>().ToTable("Contatos")
               .Property(c => c.UsuarioId)
               .HasColumnName("UsuarioId")
               .HasColumnType("int")
               .IsRequired(true);

            modelBuilder.Entity<Contato>().ToTable("Contatos")
               .Property(c => c.Telefone)
               .HasColumnName("Telefone")
               .HasColumnType("nvarchar")
               .HasMaxLength(10)
               .HasDefaultValue(null);

            modelBuilder.Entity<Contato>().ToTable("Contatos")
               .Property(c => c.Celular)
               .HasColumnName("Celular")
               .HasColumnType("nvarchar")
               .HasMaxLength(11)
               .HasDefaultValue(null);
            
            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
            modelBuilder.Entity<Contato>().HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Tabela Departamentos

            modelBuilder.Entity<Departamento>().ToTable("Departamentos")
             .Property(d => d.Id)
             .HasColumnName("Id")
             .HasColumnType("int")
             .IsRequired(true);


            modelBuilder.Entity<Departamento>().ToTable("Departamentos")
             .Property(d => d.Nome)
             .HasColumnName("Nome")
             .HasColumnType("nvarchar")
             .HasMaxLength(30)
             .IsRequired(true);
            #endregion

            #region Tabela UsuarioDepartamentos

            modelBuilder.Entity<UsuarioDepartamentos>().ToTable("UsuarioDepartamentos")
             .Property(ud => ud.Id)
             .HasColumnName("Id")
             .HasColumnType("int")
             .IsRequired(true);

            modelBuilder.Entity<UsuarioDepartamentos>().ToTable("UsuarioDepartamentos")
            .Property(ud => ud.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("int")
            .IsRequired(true);
            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
            modelBuilder.Entity<UsuarioDepartamentos>().HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Tabela EnderecosEntrega

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(e => e.Id)
               .HasColumnName("Id")
               .HasColumnType("int")
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(e => e.UsuarioId)
               .HasColumnName("UsuarioId")
               .HasColumnType("int")
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.NomeEndereco)
               .HasColumnName("NomeEndereco")
               .HasColumnType("nvarchar")
               .HasMaxLength(20)
               .HasDefaultValue(null);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.CEP)
               .HasColumnName("CEP")
               .HasColumnType("nvarchar")
               .HasMaxLength(8)
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.Estado)
               .HasColumnName("Estado")
               .HasColumnType("nvarchar")
               .HasMaxLength(2)
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.Estado)
               .HasColumnName("Estado")
               .HasColumnType("nvarchar")
               .HasMaxLength(2)
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.Cidade)
               .HasColumnName("Cidade")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
              .Property(c => c.Bairro)
              .HasColumnName("Bairro")
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
               .Property(c => c.Endereco)
               .HasColumnName("Endereco")
               .HasColumnType("nvarchar")
               .HasMaxLength(60)
               .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
              .Property(c => c.Numero)
              .HasColumnName("Numero")
              .HasColumnType("nvarchar")
              .HasMaxLength(8)
              .IsRequired(true);

            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecosEntrega")
             .Property(c => c.Complemento)
             .HasColumnName("Complemento")
             .HasColumnType("nvarchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);
            
            //relacionamento entre tabelas e comportamento cascate ao deletar usuário
            modelBuilder.Entity<EnderecoEntrega>().HasOne<Usuario>().WithMany().HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

    }
}
