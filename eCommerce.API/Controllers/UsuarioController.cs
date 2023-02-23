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
            public Task<ICollection<Usuario>> GetAll()
            {
                return _usuarioRepository.GetAll();
            }

        [HttpGet("GetById/{id}")]
        public Task<Usuario> GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }


        [HttpGet("GetBySituacaoCadastral/{situacao}")]
            public Task<ICollection<Usuario>> GetBySituacaoCadastral(SituacaoCadastral situacao)
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
