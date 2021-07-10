using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica_Viva_Bem.Models
{
    public class Patient : BaseModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Name { get; set; }
        
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O endereço é obrigatório!")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A data de nascimneto é obrigatória!")]
        public DateTime BirthDay { get; set; }

    }
}