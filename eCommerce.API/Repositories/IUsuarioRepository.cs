using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario GetByName(string name);
        Usuario GetByEmail(string email);
        Usuario GetByCPF(string cpf);
        Usuario GetByRG(string RG);
        List<Usuario> GetBySituacaoCadastral(string situacao);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);


    }
}
