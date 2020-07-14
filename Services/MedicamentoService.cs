using System.Collections.Generic;
using System.Linq;
using ApiPronutrir.ContextDb;
using ApiPronutrir.Models;

namespace ApiPronutrir.Services
{
    public class MedicamentoService
    {
        private readonly ClinicaContext _context;

        public MedicamentoService(ClinicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Medicamentos> GetAllMedicamentos(){
            
            var medicamentos = _context.Medicamentos.ToList();

            return medicamentos;

        }

        public Medicamentos find(int id){

            var medicamentos = _context.Medicamentos.FirstOrDefault(item => item.id == id);

            return medicamentos;

        }

        public void AddMedicamento(Medicamentos medicamentos){

            _context.Medicamentos.Add(medicamentos);
            _context.SaveChanges();

        }

        public void delete(int id){

            var medicamento = _context.Medicamentos.FirstOrDefault(item => item.id == id);

            _context.Remove(medicamento);
            _context.SaveChanges();

        }

        public void update(int id, Medicamentos medicamento){

            var _medicamento = find(id);
            _medicamento = medicamento;
            _context.Medicamentos.Update(_medicamento);
            _context.SaveChanges();

        }
    }
}