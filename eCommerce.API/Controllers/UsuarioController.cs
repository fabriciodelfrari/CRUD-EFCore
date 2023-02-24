using eCommerce.API.Repositories;
using eCommerce.Models;
using eCommerce.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class UsuarioController : ControllerBase
        {
            private readonly IUsuarioRepository _usuarioRepository;
            private readonly JsonSerializerSettings jsonSerializerSettings;

            public UsuarioController(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;
                jsonSerializerSettings = new JsonSerializerSettings {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
            }

            [HttpGet("GetAll")]
            public async Task<ActionResult> GetAll()
            {   
                var usuarios =  await _usuarioRepository.GetAll();

                if(usuarios == null ||usuarios.Count < 1)
                    return NotFound();

                var jsonColecao = JsonConvert.SerializeObject(usuarios, jsonSerializerSettings);

                return Ok(jsonColecao);
               
                
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
