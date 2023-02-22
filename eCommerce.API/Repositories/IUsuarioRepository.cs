using eCommerce.Models;
using eCommerce.Models.Enum;

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
        List<Usuario> GetBySituacaoCadastral(SituacaoCadastral situacao);
        Usuario Add(Usuario usuario);
        void Update(Usuario usuario);
        bool Delete(int id);


    }
}
