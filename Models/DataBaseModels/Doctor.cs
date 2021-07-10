

using System.ComponentModel.DataAnnotations;
using Clinica_Viva_Bem;
using Clinica_Viva_Bem.Enums;

namespace Clinica_Viva_Bem.Models
{
    public class Doctor : BaseModel
    {
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Phone { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Name { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}