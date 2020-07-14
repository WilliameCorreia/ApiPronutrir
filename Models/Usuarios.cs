using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPronutrir.Models
{
    public class Usuarios : IValidatableObject
    {
        public int id {get; set;}
        [Required(ErrorMessage="Login do Usúario é obrigatório")]
        public string login {get; set;}

        [Required(ErrorMessage="Senha do Usúario é obrigatório")]
        public string senha {get; set;}

        [Required(ErrorMessage="Nome do Usúario é obrigatório")]
        public string nome {get; set;}

        [Required(ErrorMessage="Sobrenome do Usúario é obrigatório")]
        public string sobrenome {get; set;}

        [Required(ErrorMessage="Data de Nascismento do Usúario é obrigatório")]
        public DateTime Nacismento {get; set;}

        [Required(ErrorMessage="è necessário informar sintuação do usuário ativo/desativado")]
        public bool ativo {get; set;}

        [Required(ErrorMessage="Cpf do Usúario é obrigatório")]
        public string cpf {get; set;}

        [Required(ErrorMessage="Tipo do Usúario é obrigatório")]
        public int tipoUsuario {get; set;}
        public string crm {get; set;}
        public int matricula {get; set;}

        [MinLength(30, ErrorMessage="Token deve ter no minimo 30 caracteres")]
        public string token {get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.tipoUsuario == 1 && this.token == null){
                yield return new ValidationResult("Token é obrigatório");
            }
        }

        public IEnumerable<ValidationResult> Validate_crm(ValidationContext validationContext)
        {
            if(this.tipoUsuario == 2 && this.token == null){
                yield return new ValidationResult("Crm é obrigatório");
            }
        }

    }
}