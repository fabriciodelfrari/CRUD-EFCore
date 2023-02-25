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

            var usuarios = await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .ToListAsync()!;

            if (usuarios.Count < 1)
                return null;

            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .FirstOrDefaultAsync(u => u.Id == id)!;

            return usuario;
        }

        public async Task<ICollection<Usuario>> GetBySituacaoCadastral(SituacaoCadastral situacao)
        {
            var usuarios = await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .Where(u => u.SituacaoCadastral == situacao)
                .ToListAsync()!;

            if (usuarios.Count < 1)
                return null;

            return usuarios;
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

        public async Task<Usuario> AddEndereco(EnderecoEntrega enderecoEntrega)
        {
            var usuario = await GetById(enderecoEntrega.UsuarioId);

            if (usuario == null)
                throw new Exception("Usuário não encontrado no banco de dados.");

            if (usuario.EnderecosEntrega.Contains(enderecoEntrega))
                throw new Exception("Usuário já possui este endereço cadastrado.");

            if (usuario.EnderecosEntrega == null)
                usuario.EnderecosEntrega = new List<EnderecoEntrega>();

            usuario.EnderecosEntrega.Add(enderecoEntrega);

            _db.SaveChanges();

            return usuario;

        }


    }
}
