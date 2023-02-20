using eCommerce.API.Repositories;
using eCommerce.Models;
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

            [HttpGet]
            public List<Usuario> GetAll()
            {
                return _usuarioRepository.GetAll();
            }

            [HttpGet("{id}")]
            public Usuario GetById(int id)
            {
                return _usuarioRepository.GetById(id);
            }

            [HttpGet("name/{name}")]
            public Usuario GetByName(string name)
            {
                return _usuarioRepository.GetByName(name);
            }

            [HttpGet("email/{email}")]
            public Usuario GetByEmail(string email)
            {
                return _usuarioRepository.GetByEmail(email);
            }

            [HttpGet("cpf/{cpf}")]
            public Usuario GetByCPF(string cpf)
            {
                return _usuarioRepository.GetByCPF(cpf);
            }

            [HttpGet("rg/{rg}")]
            public Usuario GetByRG(string rg)
            {
                return _usuarioRepository.GetByRG(rg);
            }

            [HttpGet("situacao/{situacao}")]
            public List<Usuario> GetBySituacaoCadastral(string situacao)
            {
                return _usuarioRepository.GetBySituacaoCadastral(situacao);
            }

            [HttpPost]
            public void Add([FromBody] Usuario usuario)
            {
                _usuarioRepository.Add(usuario);
            }

            [HttpPut("{id}")]
            public void Update([FromBody] Usuario usuario)
            {
                _usuarioRepository.Update(usuario);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                _usuarioRepository.Delete(id);
            }
        }
}
