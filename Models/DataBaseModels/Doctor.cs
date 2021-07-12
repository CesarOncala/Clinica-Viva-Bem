

using System.ComponentModel.DataAnnotations;
using Clinica_Viva_Bem;
using Clinica_Viva_Bem.Enums;

namespace Clinica_Viva_Bem.Models
{
    public class Doctor : BaseModel
    {
        [StringLength(13,MinimumLength =11,ErrorMessage ="Maximum length is 13 and Minimum are so 11")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Phone { get; set; }

        [StringLength(32,MinimumLength =5,ErrorMessage ="Type a name with mininum 5 characters")]
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Name { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}