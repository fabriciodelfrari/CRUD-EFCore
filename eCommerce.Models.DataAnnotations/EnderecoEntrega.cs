using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [MaxLength(20)]
        public string? NomeEndereço { get; set; } //descrição do endereço, exemplo: Casa, trabalho, etc

        [Required]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(60)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(8)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string? Complemento { get; set; }


        public EnderecoEntrega()
        {

        }


        public EnderecoEntrega(int id,
            int usuarioId,
            string? nomeEndereço,
            string cep,
            string estado,
            string cidade,
            string bairro,
            string endereco,
            string numero,
            string? complemento)
        {
            Id = id;
            UsuarioId = usuarioId;
            NomeEndereço = nomeEndereço;
            CEP = cep ?? throw new ArgumentNullException(nameof(cep));
            Estado = estado ?? throw new ArgumentNullException(nameof(estado));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            Complemento = complemento;
        }
    }
}
