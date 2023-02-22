using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? NomeEndereço { get; set; } //descrição do endereço, exemplo: Casa, trabalho, etc
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
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
