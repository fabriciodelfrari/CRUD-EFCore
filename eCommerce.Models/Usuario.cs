using eCommerce.Models.Enum;

namespace eCommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? RG { get; set; }
        public string CPF { get; set; }
        public string? NomeMae { get; set; }
        public SituacaoCadastral? SituacaoCadastral { get; set; }
        public DateTime DataCadastro { get; set; }
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<UsuarioDepartamentos>? Departamentos { get; set; }

        public Usuario(int id,
            string nome,
            string email,
            string? rg,
            string cpf,
            string? nomeMae,
            SituacaoCadastral situacaoCadastral,
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
            DataCadastro = DateTime.UtcNow;
            Contato = contato;
            EnderecosEntrega = enderecosEntrega;
            Departamentos = departamentos;
        }
    }
}