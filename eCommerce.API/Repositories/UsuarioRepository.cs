using eCommerce.API.Database;
using eCommerce.Models;
using eCommerce.Models.Enum;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly eCommerceContext _db;

        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }

        public List<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario GetByCPF(string cpf)
        {
            return _db.Usuarios.FirstOrDefault(u => u.CPF == cpf, null)!;
        }

        public Usuario GetByEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Email == email, null)!;
        }

        public Usuario GetById(int id)
        {
            return _db.Usuarios.Find(id)!;
        }

        public Usuario GetByName(string nome)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Nome == nome, null)!;
        }

        public Usuario GetByRG(string rg)
        {
            return _db.Usuarios.FirstOrDefault(u => u.RG == rg, null)!;
        }

        public List<Usuario> GetBySituacaoCadastral(SituacaoCadastral situacao)
        {
            return _db.Usuarios.Where(u => u.SituacaoCadastral == situacao).ToList();
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

            if(usuario != null)
            {
                _db.Usuarios.Remove(usuario);

                _db.SaveChanges();

                return true;
            }

            return false;
        }

        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();

        }
    }
}
