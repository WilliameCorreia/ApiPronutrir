using System;
using System.Collections.Generic;

namespace ApiPronutrir.Models
{
    public class Categorias
    {
        public Categorias()
        {
            Medicamentos = new HashSet<Medicamentos>();
        }
        public int id {get; set;}

        public string nome {get; set;}

        public DateTime data {get; set;}

        public virtual ICollection<Medicamentos> Medicamentos {get; set;}
    }
}