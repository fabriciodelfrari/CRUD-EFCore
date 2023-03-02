using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using eCommerce.Infra.MapeamentoConfigs;

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
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioConfig()); //indica o mapeamento da model Usuario
            modelBuilder.ApplyConfiguration(new ContatoConfig()); //indica o mapeamento da modell Contato
            modelBuilder.ApplyConfiguration(new DepartamentoConfig()); //indica o mapeamento da model Departamento
            modelBuilder.ApplyConfiguration(new EnderecoEntregaConfig()); //indica o mapeamento da model EnderecoEntrega
            
        }

    }
}
