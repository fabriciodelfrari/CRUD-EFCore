using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class UsuarioDepartamentos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }

        public UsuarioDepartamentos()
        {
          
        }

    }
}
