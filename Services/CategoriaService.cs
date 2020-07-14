using System.Collections.Generic;
using System.Linq;
using ApiPronutrir.ContextDb;
using ApiPronutrir.Models;

namespace ApiPronutrir.Services
{
    public class CategoriaService
    {
        private readonly ClinicaContext _context;

        public CategoriaService(ClinicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Categorias> GetAllCategorias(){
            
            var categorias = _context.categorias.ToList();

            return categorias;

        }

        public Categorias find(int id){

            var Categoria = _context.categorias.FirstOrDefault(item => item.id == id);

            return Categoria;

        }

        public void AddCategoria(Categorias categoria){

            _context.categorias.Add(categoria);
            _context.SaveChanges();

        }

        public void delete(int id){

            var categoria = _context.categorias.FirstOrDefault(item => item.id == id);

            _context.Remove(categoria);
            _context.SaveChanges();

        }

        public void update(int id, Categorias categoria){

            var _categoria = find(id);
            _categoria = categoria;
            _context.categorias.Update(_categoria);
            _context.SaveChanges();

        }
    }
}