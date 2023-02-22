using eCommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(254)]
        public string Email { get; set; }

        [MaxLength(12)]
        public string? RG { get; set; }

        [MaxLength(12)]
        public string CPF { get; set; }

        [MaxLength(60)]
        public string? NomeMae { get; set; }

        [MaxLength(1)]
        public SituacaoCadastral? SituacaoCadastral { get; set; }

        [Required]
        [MaxLength(19)]
        public DateTime DataCadastro { get; set; }
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<UsuarioDepartamentos>? Departamentos { get; set; }


        public Usuario()
        {
            Id = 0;
            Nome = string.Empty;
            Email = string.Empty;
            CPF = string.Empty;
            
        }

        public Usuario(int id,
            string nome,
            string email,
            string? rg,
            string cpf,
            string? nomeMae,
            SituacaoCadastral situacaoCadastral,
            DateTime dataCadastro,
            Contato? contato,
            ICollection<EnderecoEntrega>? enderecosEntrega,
            ICollection<UsuarioDepartamentos>? departamentos)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            RG = rg;
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            NomeMae = nomeMae;
            SituacaoCadastral = situacaoCadastral;
            DataCadastro = dataCadastro;
            Contato = contato;
            EnderecosEntrega = enderecosEntrega;
            Departamentos = departamentos;
        }
    }
}