using ApiPronutrir.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPronutrir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MedicamentoService _medicamentoService;

        public UsuarioController(MedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        public ActionResult Index(){

            //var Lista_medicamentos =
        }
    }
}