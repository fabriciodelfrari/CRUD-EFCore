using eCommerce.API.Repositories;
using eCommerce.Models;
using eCommerce.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class UsuarioController : ControllerBase
        {
            private readonly IUsuarioRepository _usuarioRepository;

            public UsuarioController(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;
            }

            [HttpGet("GetAll")]
            public ICollection<Usuario> GetAll()
            {
                return _usuarioRepository.GetAll();
            }

            [HttpGet("GetById/{id}")]
            public Usuario GetById(int id)
            {
                return _usuarioRepository.GetById(id);
            }

            [HttpGet("GetByName")]
            public Usuario GetByName([FromBody] string nome)
            {
                return _usuarioRepository.GetByName(nome);
            }

            [HttpGet("GetByEmail")]
            public Usuario GetByEmail([FromBody] string email)
            {
                return _usuarioRepository.GetByEmail(email);
            }

            [HttpGet("GetByCpf")]
            public Usuario GetByCPF([FromBody] string cpf)
            {
                return _usuarioRepository.GetByCPF(cpf);
            }

            [HttpGet("GetByRg")]
            public Usuario GetByRG([FromBody] string rg)
            {
                return _usuarioRepository.GetByRG(rg);
            }

            [HttpGet("GetBySituacaoCadastral/{situacao}")]
            public List<Usuario> GetBySituacaoCadastral(SituacaoCadastral situacao)
            {
                return _usuarioRepository.GetBySituacaoCadastral(situacao);
            }

            [HttpPost("Add")]
            public void Add([FromBody] Usuario usuario)
            {
                _usuarioRepository.Add(usuario);
            }

            [HttpPut("Update")]
            public void Update([FromBody] Usuario usuario)
            {
                _usuarioRepository.Update(usuario);
            }

            [HttpDelete("Delete/{id}")]
            public void Delete(int id)
            {
                _usuarioRepository.Delete(id);
            }
        }
}
