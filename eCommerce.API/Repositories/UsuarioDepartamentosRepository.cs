
using eCommerce.Models;
using eCommerce.API.Database;

namespace eCommerce.API.Repositories
{
    public class UsuarioDepartamentosRepository : IUsuarioDepartamentosRepository
    {
        private readonly eCommerceContext _db;
        public UsuarioDepartamentos Add(UsuarioDepartamentos usuarioDepartamentos)
        {
            if(usuarioDepartamentos.Departamento.Id == 0 || usuarioDepartamentos.UsuarioId == 0)
                return null!;


            _db.UsuarioDepartamentos.Add(usuarioDepartamentos);

            return _db.UsuarioDepartamentos.FirstOrDefault(ud => ud == usuarioDepartamentos)!;
        }
    }
}