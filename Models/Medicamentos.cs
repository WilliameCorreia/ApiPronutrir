using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPronutrir.Models
{
    public class Medicamentos : IValidatableObject
    {
        public int id {get; set;}
        [Required(ErrorMessage="Nome do Medicamento é obrigatório")]
        [MinLength(5, ErrorMessage="Nome deve ter no minimo 5 caracteres")]
        [MaxLength(30, ErrorMessage="Nome deve ter no maximo 30 caracteres")]
        public string nome {get; set;}
        [Required(ErrorMessage="Nome do Medicamento é obrigatório")]
        public decimal quantidade {get; set;}

        [Required(ErrorMessage="Data de validade do Medicamento é obrigatório")]
        public DateTime Validade {get; set;}
        public int? categoriaId {get; set;}
        public virtual Categorias Categoria {get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.Validade < DateTime.Now){
                yield return new ValidationResult("A data de validade não pode ser menor do que o dia atual");
            }
        }
    }
}