using eCommerce.API.Repositories;
using eCommerce.Models;
using eCommerce.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;

        }

        [HttpGet("GetAll")]
        public ActionResult<ICollection<Departamento>> GetAll()
        {
            try
            {
                var departamentos = _departamentoRepository.GetAll();

                if (departamentos.Count < 1)
                    return BadRequest();


                return departamentos.ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}