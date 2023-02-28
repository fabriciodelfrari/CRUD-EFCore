using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.ViewModels
{
    public class ViewModelUsuarioDepartamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } 
        public string Nome { get; set; }
        

        public ViewModelUsuarioDepartamento()
        {
        }
    }
}
