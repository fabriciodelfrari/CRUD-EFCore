using eCommerce.API.Database;
using eCommerce.Models;
using eCommerce.Models.Enum;
using eCommerce.Models.ViewModels;
using eCommerce.API.Repositories.Exceptions;
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
            try
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
            catch (Exception e)
            {
                throw new UsuarioRepositoryException($"Erro ao consulta lista de usuários: {e.Message}", e);
            }

           
        }

        public async Task<Usuario> GetById(int id)
        {
            try{
                var usuario = await _db.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.EnderecosEntrega)
                .Include(u => u.Departamentos)
                .FirstOrDefaultAsync(u => u.Id == id)!;

            return usuario;
            }
            catch(Exception e){
                throw new UsuarioRepositoryException($"Erro ao consultar usuário: {e.Message}", e);
            }
            
        }

        public async Task<ICollection<Usuario>> GetBySituacaoCadastral(SituacaoCadastral situacao)
        {

            try
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
            catch (Exception e)
            {
                
                throw new UsuarioRepositoryException($"Erro ao listar usuários pela situação cadastral: {e.Message}", e);
            }
            
        }
        public Usuario Add(Usuario usuario)
        {
            try
            {
                 _db.Usuarios.Add(usuario);

            _db.SaveChanges();

            return _db.Usuarios.FirstOrDefault(u => u == usuario)!;
            }
            catch (Exception e)
            {
                throw new UsuarioRepositoryException($"Erro ao cadastrar usuário: {e.Message}", e);
            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                var usuario = _db.Usuarios.Find(id);

            if (usuario == null)
                return false;  

            _db.Usuarios.Remove(usuario);

                _db.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                
                throw new UsuarioRepositoryException($"Erro ao deletar cadastro de usuário: {e.Message}", e);
            }
            
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            try
            {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();

            return usuario;

            }
            catch (Exception e)
            {
                throw new UsuarioRepositoryException($"Erro ao alterar cadastro de usuário: {e.Message}", e);
            }
           

        }

        public async Task<Usuario> AddEndereco(EnderecoEntrega enderecoEntrega)
        {

            try
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

            return usuario;
            }
            catch (Exception e)
            {
                
                throw new UsuarioRepositoryException($"Erro ao vincular endereço ao usuário: {e.Message}", e);
            }
            

        }

        public async Task<Usuario> UpdateEndereco(EnderecoEntrega enderecoEntrega)
        {
            try
            {
                var usuario = await GetById(enderecoEntrega.UsuarioId);

            if (!UsuarioJaPossuiEnderecoCadastrado(enderecoEntrega))
                throw new Exception("Usuário não possui este endereço cadastrado.");
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
                throw new UsuarioRepositoryException($"Erro ao alterar o endereço: {e.Message}", e);
            }
        }

        public async Task<Usuario> RemoveEndereco(EnderecoEntrega enderecoEntrega)
        {
            
            try
            {
                var usuario = await GetById(enderecoEntrega.UsuarioId);

            if (!UsuarioJaPossuiEnderecoCadastrado(enderecoEntrega))
                throw new Exception("Usuário não possui este endereço cadastrado.");

                usuario.EnderecosEntrega.Remove(usuario.EnderecosEntrega.First(e => e.Id == enderecoEntrega.Id));
                _db.SaveChanges();

                return usuario;
            }
            catch (Exception e)
            {
                throw new UsuarioRepositoryException($"Erro ao excluir endereço: {e.Message}", e);
            }
        }


        public async Task<Usuario> AddDepartamento(ViewModelUsuarioDepartamento usuarioDepartamento)
        {

            try
            {
                 var usuario = await GetById(usuarioDepartamento.UsuarioId);
           var departamento = _db.Departamentos.Find(usuarioDepartamento.Id);


            if (usuario == null)
                throw new Exception("Usuário não encontrado no banco de dados."); 

            if(departamento == null)
                throw new Exception("Departamento informado não existe.");

            if(usuario.Departamentos == null)
                usuario.Departamentos = new List<Departamento>();

            if (DepartamentoJaVinculadoAoUsuario(usuario, departamento))
                throw new Exception("Usuário já possui este endereço cadastrado.");

            usuario.Departamentos.Add(departamento);

            _db.SaveChanges();

            return usuario;
            }
            catch (Exception e)
            {
                
                throw new UsuarioRepositoryException($"Erro ao vincular departamento ao usuário: {e.Message}", e);
            }
           
        }
    
        public async Task<Usuario> RemoveDepartamento(ViewModelUsuarioDepartamento usuarioDepartamento)
        {
            try
            {
                var usuario = await GetById(usuarioDepartamento.UsuarioId);
            var departamento = _db.Departamentos.Find(usuarioDepartamento.Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado no banco de dados."); 
            
            if(departamento == null)
                throw new Exception("Departamento informado não existe.");

            if(usuario.Departamentos == null)
                throw new Exception("Usuário não possui departamentos cadastrados.");

            
            usuario.Departamentos.Remove(usuario.Departamentos.FirstOrDefault(d => d.Id == departamento.Id)!);

            _db.SaveChanges();

            return usuario;
            }
            catch (Exception e)
            {
                
                throw new UsuarioRepositoryException($"Erro ao remover departamento do usuário: {e.Message}", e);
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

        private bool DepartamentoJaVinculadoAoUsuario(Usuario usuario, Departamento departamento)
        {
            return usuario.Departamentos!.Any(d => d.Nome == departamento.Nome);
        }

    }
}
