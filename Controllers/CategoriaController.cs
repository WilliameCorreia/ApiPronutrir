using ApiPronutrir.Models;
using ApiPronutrir.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPronutrir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult GetAll(){

            var Lista_categorias = _categoriaService.GetAllCategorias();

            return Ok(Lista_categorias);
        }

        [HttpGet("{id}", Name="getCategoria")]
        public ActionResult GetById(int id){

            var categoria = _categoriaService.find(id);

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                return new ObjectResult(categoria);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Categorias categoria){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _categoriaService.AddCategoria(categoria);
                return CreatedAtRoute("getCategoria", new{id = categoria.id}, categoria);
            }
        }

        [HttpDelete("{id")]
        public ActionResult Delete(int id){
            if(id == 0 || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _categoriaService.delete(id);
                return Ok();
            }
        }

        [HttpPut("id")]
        public ActionResult Update(int id, [FromBody] Categorias categoria){
            if(categoria.id != id || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _categoriaService.update(id, categoria);
                return Ok();
            }
        }
    }
}