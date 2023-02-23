using eCommerce.API.Repositories;
using eCommerce.Models;
using eCommerce.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioDepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        
    }
}