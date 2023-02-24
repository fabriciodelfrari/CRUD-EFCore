using eCommerce.API.Database;
using eCommerce.Models;
using eCommerce.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly eCommerceContext _db;

        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Usuario>> GetAll()
        {

            return await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .ToListAsync()!;
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .FirstOrDefaultAsync(u => u.Id == id)!;
        }

        public async Task<ICollection<Usuario>> GetBySituacaoCadastral(SituacaoCadastral situacao)
        {
            return await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .Where(u => u.SituacaoCadastral == situacao)
                .ToListAsync()!;
        }
        public Usuario Add(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);

            _db.SaveChanges();

            return _db.Usuarios.FirstOrDefault(u => u == usuario)!;
        }

        public bool Delete(int id)
        {
            var usuario = _db.Usuarios.Find(id);

            if (usuario != null)
            {
                _db.Usuarios.Remove(usuario);

                _db.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();

            return await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .FirstOrDefaultAsync(u => u.Id == usuario.Id)!;

        }

       
    }
}
