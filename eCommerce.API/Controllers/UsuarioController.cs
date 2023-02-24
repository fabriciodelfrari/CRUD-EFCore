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
            jsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAll();

                if (usuarios == null || usuarios.Count < 1)
                    return NotFound();

                var jsonColecao = JsonConvert.SerializeObject(usuarios, jsonSerializerSettings);

                return Ok(jsonColecao);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetById(id);

                if (usuario == null)
                    return NotFound();


                return Ok(JsonConvert.SerializeObject(usuario, jsonSerializerSettings));


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetBySituacaoCadastral/{situacao}")]
        public async Task<ActionResult> GetBySituacaoCadastral(SituacaoCadastral situacao)
        {
            try
            {
                var usuarios = await _usuarioRepository.GetBySituacaoCadastral(situacao);

                if (usuarios == null)
                    return NotFound();

                return Ok(JsonConvert.SerializeObject(usuarios, jsonSerializerSettings));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _usuarioRepository.Add(usuario);

                return Ok(usuarioCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] Usuario usuario)
        {

            try
            {
                var usuarioAlterado = _usuarioRepository.Update(usuario);

                return Ok(usuarioAlterado);
            }
            catch (Exception e)
            {
                return BadRequest(JsonConvert.SerializeObject(e.Message, jsonSerializerSettings));
            }
            
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                 _usuarioRepository.Delete(id);

                 return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(JsonConvert.SerializeObject(e.Message, jsonSerializerSettings));
            }
           
        }
    }
}
