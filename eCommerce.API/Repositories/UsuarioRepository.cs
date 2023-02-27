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

            if (UsuarioJaPossuiEnderecoCadastrado(enderecoEntrega))
                throw new Exception("Usuário já possui este endereço cadastrado.");

            if (usuario.EnderecosEntrega == null)
                usuario.EnderecosEntrega = new List<EnderecoEntrega>();

            usuario.EnderecosEntrega.Add(enderecoEntrega);

            _db.SaveChanges();

            usuario = await GetById(enderecoEntrega.UsuarioId); //garantir que o usuário retornado é o que está no banco

            return usuario;

        }

        public async Task<Usuario> UpdateEndereco(EnderecoEntrega enderecoEntrega){

            var usuario = await GetById(enderecoEntrega.UsuarioId);

            if (!UsuarioJaPossuiEnderecoCadastrado(enderecoEntrega))
                throw new Exception("Usuário não possui este endereço cadastrado.");

            try
            {
                var endereco = usuario.EnderecosEntrega.First(e => e.Id == enderecoEntrega.Id);

                endereco.NomeEndereco = enderecoEntrega.NomeEndereco;
                endereco.CEP = enderecoEntrega.CEP;
                endereco.Estado = enderecoEntrega.Estado;
                endereco.Cidade = enderecoEntrega.Cidade;
                endereco.Bairro = enderecoEntrega.Bairro;
                endereco.Endereco = enderecoEntrega.Endereco;
                endereco.Numero = enderecoEntrega.Numero;
                endereco.Complemento = enderecoEntrega.Complemento;

                await _db.SaveChangesAsync();

                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao alterar o endereço.", e);
            }
        }

        public async Task<Usuario> RemoveEndereco(EnderecoEntrega enderecoEntrega)
        {
            var usuario = await GetById(enderecoEntrega.UsuarioId);

            if (!UsuarioJaPossuiEnderecoCadastrado(enderecoEntrega))
                throw new Exception("Usuário não possui este endereço cadastrado.");

            try
            {
                usuario.EnderecosEntrega.Remove(usuario.EnderecosEntrega.First(e => e.Id == enderecoEntrega.Id));
                _db.SaveChanges();

                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao excluir endereço.", e);
            }
        }

        private bool UsuarioJaPossuiEnderecoCadastrado(EnderecoEntrega enderecoEntrega)
        {
            return _db.EnderecosEntrega
                        .Any(e => e.UsuarioId == enderecoEntrega.UsuarioId
                        && e.CEP == enderecoEntrega.CEP
                        && e.Estado == enderecoEntrega.Estado
                        && e.Cidade == enderecoEntrega.Cidade
                        && e.Bairro == enderecoEntrega.Bairro
                        && e.Endereco == enderecoEntrega.Endereco
                        && e.Numero == enderecoEntrega.Numero
                        && e.Complemento == enderecoEntrega.Complemento);
        }


    }
}
