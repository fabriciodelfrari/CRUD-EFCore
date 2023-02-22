using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [MaxLength(10)]
        public string? Telefone { get; set; }
        [MaxLength(11)]
        public string? Celular { get; set; }

        


        public Contato()
        {

        }
    }
}
