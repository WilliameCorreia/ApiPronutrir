using ApiPronutrir.Models;
using ApiPronutrir.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPronutrir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly MedicamentoService _medicamentoService;

        public MedicamentoController(MedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {

            var Lista_medicamentos = _medicamentoService.GetAllMedicamentos();

            return Ok(Lista_medicamentos);

        }

        [HttpGet("{id}", Name = "getMedicamento")]
        public ActionResult GetById(int id)
        {

            var medicamento = _medicamentoService.find(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return new ObjectResult(medicamento);
            }

        }

        [HttpPost]
        public ActionResult Create([FromBody] Medicamentos medicamento){
            if(!ModelState.IsValid){
               return BadRequest(); 
            }else{
                _medicamentoService.AddMedicamento(medicamento);
                return CreatedAtRoute("getMedicamento", new{id = medicamento.id}, medicamento);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            if(id == 0 || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _medicamentoService.delete(id);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Medicamentos medicamento){
            if(medicamento.id != id || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _medicamentoService.update(id, medicamento);
                return Ok();
            }
        }


    }
}