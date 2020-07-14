namespace ApiPronutrir.Models
{
    public class Medicamentos
    {
        public int id {get; set;}
        public string nome {get; set;}
        public int quantidade {get; set;}
        public int? categoriaId {get; set;}
        public virtual Categorias Categoria {get; set;}
    }
}