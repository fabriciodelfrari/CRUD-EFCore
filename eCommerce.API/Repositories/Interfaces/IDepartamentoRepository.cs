using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public interface IDepartamentoRepository
    {
        Departamento GetById(int id);
        Departamento GetByName(string nome);
        ICollection<Departamento> GetAll();
        Departamento Add(Departamento departamento);
        Departamento Update(Departamento departamento);
        bool Delete(int id);
    }
}
