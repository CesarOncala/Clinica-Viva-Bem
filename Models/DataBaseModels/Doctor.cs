

using System.ComponentModel.DataAnnotations;
using Clinica_Viva_Bem;
using Clinica_Viva_Bem.Enums;

namespace Clinica_Viva_Bem.Models
{
    public class Doctor : BaseModel
    {
        [Required]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Desgraça")]
        public string Name { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}