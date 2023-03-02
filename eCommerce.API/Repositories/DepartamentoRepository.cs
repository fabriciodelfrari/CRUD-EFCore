using eCommerce.API.Database;
using eCommerce.Models;
using eCommerce.API.Repositories.Exceptions;

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
            try
            {
                return _db.Departamentos.FirstOrDefault(d => d.Id == id, null)!;
            }
            catch (Exception e)
            {
                throw new DepartamentoRepositoryException($"Erro ao consultar departamento: {e.Message}", e);
            }

        }
        public Departamento GetByName(string nome)
        {
            try
            {
                return _db.Departamentos.FirstOrDefault(d => d.Nome == nome, null)!;
            }
            catch (Exception e)
            {
                throw new DepartamentoRepositoryException($"Erro ao consultar departamento: {e.Message}", e);
            }

        }
        public ICollection<Departamento> GetAll()
        {
            try
            {
                return _db.Departamentos.ToList();
            }
            catch (Exception e)
            {

                throw new DepartamentoRepositoryException($"Erro ao consultar a lista de departamentos: {e.Message}", e);
            }

        }

        public Departamento Add(Departamento departamento)
        {

            try
            {
                bool depExiste = GetByName(departamento.Nome) != null;

                if (depExiste)
                    return null;

                _db.Departamentos.Add(departamento);

                _db.SaveChanges();

                return GetByName(departamento.Nome);

            }
            catch (Exception e)
            {

                throw new DepartamentoRepositoryException($"Erro ao cadastrar departamento: {e.Message}", e);
            }


        }

        public bool Delete(int id)
        {
            try
            {
                var departamento = GetById(id);

                if (departamento == null)
                    return false;

                _db.Departamentos.Remove(departamento);
                _db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {

                throw new DepartamentoRepositoryException($"Erro ao deletar departamento: {e.Message}", e);
            }

        }

        public Departamento Update(Departamento departamento)
        {
            try
            {
                _db.Departamentos.Update(departamento);

                return GetById(departamento.Id);
            }
            catch (Exception e)
            {

                throw new DepartamentoRepositoryException($"Erro ao alterar cadastro do departamento: {e.Message}", e);
            }

        }
    }
}
