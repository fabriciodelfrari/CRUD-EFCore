using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class UsuarioDepartamentos
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public Departamento Departamento { get; set; }

        public UsuarioDepartamentos()
        {
          
        }

        public UsuarioDepartamentos(int usuarioId, Departamento departamento)
        {
            Id = 0;
            UsuarioId = usuarioId;
            Departamento = departamento;

        }

    }
}
