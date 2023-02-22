using eCommerce.API.Database;
using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {

        private readonly eCommerceContext _db;

        public DepartamentoRepository(eCommerceContext db)
        {
            _db = db;
        }

        public Departamento GetById(int id)
        {
            return _db.Departamentos.FirstOrDefault(d => d.Id == id, null)!;
        }
        public Departamento GetByName(string nome)
        {
            return _db.Departamentos.FirstOrDefault(d => d.Nome == nome, null)!;
        }
        public ICollection<Departamento> GetAll()
        {
            return _db.Departamentos.ToList();
        }

        public Departamento Add(Departamento departamento)
        {
            bool depExiste = GetByName(departamento.Nome) != null;
            
            if (depExiste)
                return null;

            _db.Departamentos.Add(departamento);

            _db.SaveChanges();

            return GetByName(departamento.Nome);

        }

        public bool Delete(int id)
        {
            var departamento = GetById(id);

            if (departamento == null)
                return false;

            _db.Departamentos.Remove(departamento);
            _db.SaveChanges();

            return true;
        }

        public Departamento Update(Departamento departamento)
        {
            _db.Departamentos.Update(departamento);

            return GetById(departamento.Id);
        }
    }
}
