using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica_Viva_Bem.Models
{
    public class Patient : BaseModel
    {
        [StringLength(32,MinimumLength =5,ErrorMessage ="Type a name with mininum 5 characters")]
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Name { get; set; }
        
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O endereço é obrigatório!")]
        public string Address { get; set; }
        
        [StringLength(13,MinimumLength =11,ErrorMessage ="Maximum length is 13 and Minimum are so 11")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A data de nascimneto é obrigatória!")]
        public DateTime BirthDay { get; set; }

    }
}