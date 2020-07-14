using ApiPronutrir.Models;
using ApiPronutrir.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPronutrir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult GetAll(){

            var Lista_usuarios = _usuarioService.GetAllUsuarios();

            return Ok(Lista_usuarios);
        }

        [HttpGet("{id}", Name="getUsuario")]
        public ActionResult GetById(int id){

            var usuario = _usuarioService.find(id);

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                return new ObjectResult(usuario);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Usuarios usuario){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _usuarioService.AddUsuario(usuario);
                return CreatedAtRoute("getUsuario", new{id = usuario.id}, usuario);
            }
        }

        [HttpDelete("{id")]
        public ActionResult Delete(int id){
            if(id == 0 || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _usuarioService.delete(id);
                return Ok();
            }
        }

        [HttpPut("id")]
        public ActionResult Update(int id, [FromBody] Usuarios usuario){
            if(usuario.id != id || !ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                _usuarioService.update(id, usuario);
                return Ok();
            }
        }

    }
}