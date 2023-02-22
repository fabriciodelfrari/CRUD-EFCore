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

    }
}
