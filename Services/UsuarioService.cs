using System.Collections.Generic;
using System.Linq;
using ApiPronutrir.ContextDb;
using ApiPronutrir.Models;

namespace ApiPronutrir.Services
{
    public class UsuarioService
    {
        private readonly ClinicaContext _context;

        public UsuarioService(ClinicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuarios> GetAllUsuarios(){
            
            var usuarios = _context.Usuarios.ToList();

            return usuarios;

        }

        public Usuarios find(int id){

            var usuario = _context.Usuarios.FirstOrDefault(item => item.id == id);

            return usuario;

        }

        public void AddUsuario(Usuarios usuario){

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

        }

        public void delete(int id){

            var usuario = _context.Usuarios.FirstOrDefault(item => item.id == id);

            _context.Remove(usuario);
            _context.SaveChanges();

        }

        public void update(int id, Usuarios usuario){

            var _usuario = find(id);
            _usuario = usuario;
            _context.Usuarios.Update(_usuario);
            _context.SaveChanges();

        }
    }
}